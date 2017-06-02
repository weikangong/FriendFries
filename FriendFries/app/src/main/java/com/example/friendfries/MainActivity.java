package com.example.friendfries;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void startHost(View view) {
        Intent intent = new Intent(this, HostActivity.class);
        startActivity(intent);
    }
    public void startJoin(View view) {
        Intent intent = new Intent(this, JoinActivity.class);
        startActivity(intent);
    }
    public void startSettings(View view) {
        Intent intent = new Intent(this, SettingsActivity.class);
        startActivity(intent);
    }
}
