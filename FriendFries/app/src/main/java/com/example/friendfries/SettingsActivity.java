package com.example.friendfries;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;

public class SettingsActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_settings);
    }

    public void backToMain(View view) {
        //sends user back to start page
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }

    public void changePlayerName(View view) {
        //takes in new player name and sets player name to new name

    }
}
