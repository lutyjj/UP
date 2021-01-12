package com.example.up

import android.content.Context
import android.hardware.Sensor
import android.hardware.SensorEvent
import android.hardware.SensorEventListener
import android.hardware.SensorManager
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.TextView

class MainActivity : AppCompatActivity(), SensorEventListener {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        var sensorManager: SensorManager = getSystemService(Context.SENSOR_SERVICE) as SensorManager
        var sensorAccelerometer = sensorManager.getDefaultSensor(Sensor.TYPE_ACCELEROMETER)
        var sensorGyroscope = sensorManager.getDefaultSensor(Sensor.TYPE_GYROSCOPE)
        var sensorMagnetic = sensorManager.getDefaultSensor(Sensor.TYPE_MAGNETIC_FIELD)

        sensorManager.registerListener(this, sensorAccelerometer, SensorManager.SENSOR_DELAY_NORMAL)
        sensorManager.registerListener(this, sensorGyroscope, SensorManager.SENSOR_DELAY_NORMAL)
        sensorManager.registerListener(this, sensorMagnetic, SensorManager.SENSOR_DELAY_NORMAL)
    }

    override fun onAccuracyChanged(sensor: Sensor?, accuracy: Int) {
    }

    override fun onSensorChanged(event: SensorEvent?) {
        var txt: TextView? = null
        when (event?.sensor?.type) {
            Sensor.TYPE_ACCELEROMETER -> txt = findViewById(R.id.txtAccData)
            Sensor.TYPE_GYROSCOPE -> txt = findViewById(R.id.txtGyroData)
            Sensor.TYPE_MAGNETIC_FIELD -> txt = findViewById(R.id.txtMagnetoData)
        }

        txt?.text = "X: ${event?.values?.get(0)}, Y: ${event?.values?.get(1)}, Z: ${event?.values?.get(2)}"
    }
}