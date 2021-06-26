# Introduction
FPSRestart plugin Restarts the server when the FPS reaches a specific target designated within the configuration file

## Configuration

```bash
The settings and options can be configured in the FPSRestart file under the config directory. 
The use of a JSON editor or validation site such as jsonlint.com is recommended to avoid formatting issues and syntax errors.
```

```json

"FPS To Trigger Restart": 100.0,
"How Long The Restart should be": 300.0

```

## Notes
This plugin wont start The server after shutdown like SmoothRestart! It will need assistance with a restart script or any other software that restarts the server after Shutdown.

Here is a link to my Github with a script that will start, update Rust, update Oxide and Restart the server after shutdown. (Windows Only) https://github.com/jkole4/AIO-Updater
