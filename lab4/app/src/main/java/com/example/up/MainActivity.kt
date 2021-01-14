package com.example.up

import android.content.Context
import android.hardware.Sensor
import android.hardware.SensorEvent
import android.hardware.SensorEventListener
import android.hardware.SensorManager
import android.os.Bundle
import android.util.Log
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import kotlin.math.abs


class MainActivity : AppCompatActivity(), SensorEventListener {
    var currentX: Float = 0.0f
    var currentY: Float = 0.0f
    var currentZ: Float = 0.0f
    var prevX: Float = 0.0F
    var prevY: Float = 0.0F
    var prevZ: Float = 0.0f
    var shakeThreshold: Float = 20.0f

    var currentDropY: Float = 0.0f
    var prevDropY: Float = 0.0f
    var dropDistance: Float = 0.0f
    var dropThreshold: Float = 6.0f

    private var rotationCurrentX: Float = 0.0f
    private var rotationCheckpoint: Int = 0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        var sensorManager: SensorManager = getSystemService(Context.SENSOR_SERVICE) as SensorManager
        var sensorAccelerometer = sensorManager.getDefaultSensor(Sensor.TYPE_ACCELEROMETER)
        var sensorGyroscope = sensorManager.getDefaultSensor(Sensor.TYPE_GYROSCOPE)
        var sensorMagnetic = sensorManager.getDefaultSensor(Sensor.TYPE_MAGNETIC_FIELD)
        var sensorGravity = sensorManager.getDefaultSensor(Sensor.TYPE_GRAVITY)
        var sensorLinearAcceleration = sensorManager.getDefaultSensor(Sensor.TYPE_LINEAR_ACCELERATION)

        sensorManager.registerListener(this, sensorAccelerometer, SensorManager.SENSOR_DELAY_NORMAL)
        sensorManager.registerListener(this, sensorGyroscope, SensorManager.SENSOR_DELAY_NORMAL)
        sensorManager.registerListener(this, sensorMagnetic, SensorManager.SENSOR_DELAY_NORMAL)
        sensorManager.registerListener(this, sensorGravity, SensorManager.SENSOR_DELAY_NORMAL)
        sensorManager.registerListener(this, sensorLinearAcceleration, SensorManager.SENSOR_DELAY_NORMAL)

        var button: Button = findViewById(R.id.button)
        button.setOnClickListener {
            Toast.makeText(this, "Toast", Toast.LENGTH_SHORT).show()
        }
    }

    override fun onAccuracyChanged(sensor: Sensor?, accuracy: Int) {
    }

    override fun onSensorChanged(event: SensorEvent?) {
        if (event != null) {
            var txt: TextView? = null
            when (event.sensor.type) {
                Sensor.TYPE_ACCELEROMETER -> {
                    checkShake(event)
                    txt = findViewById(R.id.txtAccData)
                }
                Sensor.TYPE_GYROSCOPE -> txt = findViewById(R.id.txtGyroData)
                Sensor.TYPE_MAGNETIC_FIELD -> txt = findViewById(R.id.txtMagnetoData)
                Sensor.TYPE_GRAVITY -> { checkFlip(event) }
                Sensor.TYPE_LINEAR_ACCELERATION -> { checkDrop(event) }
            }

            if (event.sensor.type != Sensor.TYPE_LINEAR_ACCELERATION && event.sensor.type != Sensor.TYPE_GRAVITY)
                txt?.text = "X: ${event.values[0]}, Y: ${event.values[1]}, Z: ${event.values[2]}"
        }
    }

    private fun checkDrop(event: SensorEvent) {
        currentDropY = event.values[1]

        if (prevDropY != 0.0f) {
                var diffY = currentDropY - prevDropY

                //Log.d("Diff", "Drop diff: $diffY, current drop distance: $dropDistance")
                if (diffY < -2.5f) {
                    dropDistance += abs(diffY)
                } else dropDistance = 0.0f

                if (dropDistance >= dropThreshold) {
                    Toast.makeText(this, "Drop detected", Toast.LENGTH_SHORT).show()
                    dropDistance = 0.0f
                }
        }

        prevDropY = currentDropY
    }

    private fun checkFlip(event: SensorEvent) {
        rotationCurrentX = event.values[0]

        Log.d("ROTATION", "currentRotation: $rotationCurrentX, checkpoint = $rotationCheckpoint")
        if (rotationCheckpoint == 0 && (rotationCurrentX <= 0.5 && rotationCurrentX >= -0.5)) {
            rotationCheckpoint = 1
        }
        if (rotationCheckpoint == 1 && (rotationCurrentX >= 9.5 || rotationCurrentX <= -9.5)) {
            rotationCheckpoint = 2
        }
        if (rotationCheckpoint == 2 && (rotationCurrentX <= 0.5 && rotationCurrentX >= -0.5)) {
            rotationCheckpoint = 3
        }
        if (rotationCheckpoint == 3 && (rotationCurrentX >= 9.5 || rotationCurrentX <= -9.5)) {
            rotationCheckpoint = 4
        }
        if (rotationCheckpoint == 4 && (rotationCurrentX <= 0.5 && rotationCurrentX >= -0.5)) {
            rotationCheckpoint = 0
            Toast.makeText(this, "Full rotation detected", Toast.LENGTH_SHORT).show()
        }
    }

    private fun checkShake(event: SensorEvent) {
        currentX = event.values[0]
        currentY = event.values[1]
        currentZ = event.values[2]

        if (prevX != 0f && prevY != 0f && prevZ != 0f) {
            var diffX = abs(prevX - currentX)
            var diffY = abs(prevY - currentY)
            var diffZ = abs(prevZ - currentZ)

            if ((diffX > shakeThreshold && diffY > shakeThreshold) || (diffX > shakeThreshold && diffZ > shakeThreshold) || (diffY > shakeThreshold && diffZ > shakeThreshold)) {
                Toast.makeText(this, "Shake detected", Toast.LENGTH_SHORT).show()
            }
        }

        prevX = currentX
        prevY = currentY
        prevZ = currentZ
    }
}