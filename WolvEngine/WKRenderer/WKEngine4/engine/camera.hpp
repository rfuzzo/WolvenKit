#pragma once
/*
* Basic camera class
*
* Copyright (C) 2016 by Sascha Willems - www.saschawillems.de
*
* This code is licensed under the MIT license (MIT) (http://opensource.org/licenses/MIT)
*/

#define GLM_FORCE_RADIANS
#include <glm/glm.hpp>
#include <glm/gtc/quaternion.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtx/matrix_decompose.hpp>

class Camera
{
private:
	float _fov;
	float _znear, _zfar;
    glm::vec3 _rotation = glm::vec3();
    glm::vec3 _position = glm::vec3();
    float _rotationSpeed = 1.0f;
    float _movementSpeed = 1.0f;

	void updateViewMatrix()
	{
		glm::mat4 rotM = glm::mat4(1.0f);
		glm::mat4 transM;

		rotM = glm::rotate(rotM, glm::radians(_rotation.x * (flipY ? -1.0f : 1.0f)), glm::vec3(1.0f, 0.0f, 0.0f));
		rotM = glm::rotate(rotM, glm::radians(_rotation.y), glm::vec3(0.0f, 1.0f, 0.0f));
		rotM = glm::rotate(rotM, glm::radians(_rotation.z), glm::vec3(0.0f, 0.0f, 1.0f));

		glm::vec3 translation = _position;
		
		if (flipY) {
			translation.y *= -1.0f;
		}

		transM = glm::translate(glm::mat4(1.0f), translation);

		if (type == CameraType::firstperson)
		{
			matrices.view = rotM * transM;
			matrices.viewproj = matrices.perspective * matrices.view;
		}
		else
		{
			matrices.view = transM * rotM;
			matrices.view = glm::inverse(matrices.view);
			matrices.viewproj = matrices.perspective * matrices.view;
		}

		updated = true;
	};
public:
	enum CameraType { lookat, firstperson };
	CameraType type = CameraType::lookat;

	bool updated = false;
	bool flipY = false;

    struct GPUCameraData {
        glm::mat4 view;
        glm::mat4 perspective;
        glm::mat4 viewproj;
    } matrices;

	struct
	{
		bool left = false;
		bool right = false;
		bool up = false;
		bool down = false;
	} keys;

	bool moving()
	{
		return keys.left || keys.right || keys.up || keys.down;
	}

	float getNearClip() { 
		return _znear;
	}

	float getFarClip() {
		return _zfar;
	}

	void setPerspective(float fov, float aspect, float znear, float zfar)
	{
		_fov = fov;
		_znear = znear;
		_zfar = zfar;
		matrices.perspective = glm::perspective(glm::radians(_fov), aspect, _znear, _zfar);
		if (flipY) {
			matrices.perspective[1][1] *= -1;
			matrices.viewproj = matrices.perspective * matrices.view;
		}
	};

	void updateAspectRatio(float aspect)
	{
		matrices.perspective = glm::perspective(glm::radians(_fov), aspect, _znear, _zfar);
		if (flipY) {
			matrices.perspective[1][1] *= -1.0f;
			matrices.viewproj = matrices.perspective * matrices.view;
		}
	}

	void setPosition(glm::vec3 position)
	{
		_position = position;
		updateViewMatrix();
	}

	glm::vec3 getPosition() const
	{
		return _position;
	}

	void setRotation(glm::vec3 rotation)
	{
		_rotation = rotation;
		updateViewMatrix();
	}

	void rotate(glm::vec3 delta)
	{
		_rotation += delta;
		// clamp rotation
		while (_rotation.x > 360.0f)
			_rotation.x -= 360.0f;
        while (_rotation.y > 360.0f)
            _rotation.y -= 360.0f;
        while (_rotation.y > 360.0f)
            _rotation.y -= 360.0f;

        while (_rotation.x < -360.0f)
            _rotation.x += 360.0f;
        while (_rotation.y < -360.0f)
            _rotation.y += 360.0f;
        while (_rotation.y < -360.0f)
            _rotation.y += 360.0f;
		updateViewMatrix();
	}

	void translate(glm::vec3 delta)
	{
		_position += delta;
		updateViewMatrix();
	}

	void setRotationSpeed(float rotationSpeed)
	{
		_rotationSpeed = rotationSpeed;
	}

	float getRotationSpeed() const
	{
		return _rotationSpeed;
	}

	void setMovementSpeed(float movementSpeed)
	{
		_movementSpeed = movementSpeed;
	}

	void update(float deltaTime)
	{
		updated = false;
		if (type == CameraType::firstperson)
		{
			if (moving())
			{
				glm::vec3 camFront;
				camFront.x = -cos(glm::radians(_rotation.x)) * sin(glm::radians(_rotation.y));
				camFront.y = sin(glm::radians(_rotation.x));
				camFront.z = cos(glm::radians(_rotation.x)) * cos(glm::radians(_rotation.y));

				float moveSpeed = deltaTime * _movementSpeed;

				if (keys.up)
					_position -= camFront * moveSpeed;
				if (keys.down)
					_position += camFront * moveSpeed;
				if (keys.left)
					_position -= glm::normalize(glm::cross(camFront, glm::vec3(0.0f, 1.0f, 0.0f))) * moveSpeed;
				if (keys.right)
					_position += glm::normalize(glm::cross(camFront, glm::vec3(0.0f, 1.0f, 0.0f))) * moveSpeed;
				updateViewMatrix();
			}
		}
	};

	// Update camera passing separate axis data (gamepad)
	// Returns true if view or position has been changed
	bool updatePad(glm::vec2 axisLeft, glm::vec2 axisRight, float deltaTime)
	{
		bool retVal = false;

		if (type == CameraType::firstperson)
		{
			// Use the common console thumbstick layout		
			// Left = view, right = move

			const float deadZone = 0.0015f;
			const float range = 1.0f - deadZone;

			glm::vec3 camFront;
			camFront.x = -cos(glm::radians(_rotation.x)) * sin(glm::radians(_rotation.y));
			camFront.y = sin(glm::radians(_rotation.x));
			camFront.z = cos(glm::radians(_rotation.x)) * cos(glm::radians(_rotation.y));
			camFront = glm::normalize(camFront);

			float moveSpeed = deltaTime * _movementSpeed * 2.0f;
			float rotSpeed = deltaTime * _rotationSpeed * 50.0f;
			 
			// Move
			if (fabsf(axisLeft.y) > deadZone)
			{
				float pos = (fabsf(axisLeft.y) - deadZone) / range;
				_position -= camFront * pos * ((axisLeft.y < 0.0f) ? -1.0f : 1.0f) * moveSpeed;
				retVal = true;
			}
			if (fabsf(axisLeft.x) > deadZone)
			{
				float pos = (fabsf(axisLeft.x) - deadZone) / range;
				_position += glm::normalize(glm::cross(camFront, glm::vec3(0.0f, 1.0f, 0.0f))) * pos * ((axisLeft.x < 0.0f) ? -1.0f : 1.0f) * moveSpeed;
				retVal = true;
			}

			// Rotate
			if (fabsf(axisRight.x) > deadZone)
			{
				float pos = (fabsf(axisRight.x) - deadZone) / range;
				_rotation.y += pos * ((axisRight.x < 0.0f) ? -1.0f : 1.0f) * rotSpeed;
				retVal = true;
			}
			if (fabsf(axisRight.y) > deadZone)
			{
				float pos = (fabsf(axisRight.y) - deadZone) / range;
				_rotation.x -= pos * ((axisRight.y < 0.0f) ? -1.0f : 1.0f) * rotSpeed;
				retVal = true;
			}
		}
		else
		{
			// todo: move code from example base class for look-at
		}

		if (retVal)
		{
			updateViewMatrix();
		}

		return retVal;
	}

	void focus(glm::vec3 eye, glm::vec3 center)
	{
        glm::mat4 viewspace = glm::lookAt(eye, center, glm::vec3(0, 1, 0));
		glm::mat4 transformation = glm::inverse(viewspace);
            
        glm::vec3 scale;
        glm::quat rot;
        glm::vec3 trans;
        glm::vec3 skew;
        glm::vec4 perspective;
        glm::decompose(transformation, scale, rot, trans, skew, perspective);

        // change quaternion into vec3
        _rotation = glm::degrees(glm::eulerAngles(rot));
		_rotation.y -= 90.0f;

		_position = eye;

		updateViewMatrix();
    }
};