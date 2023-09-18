# FlappyBird

A Flappy Bird game clone made using Unity

## Objectives:
- Flappy Bird player movement and input controls
- Bird Animations
- Camera Movement with Bird Movement
- Background generation
- Pipe generation with randomised positions
- Destruction of background & pipes once they are in behind out of screen
- Scoring System
- Difficulty System
- Time Counter
- Game Loss logic
- Pause screen

## Main Lessons:
- Rigidbody velocity based movement
- Fundamental use of Animation system i.e. generate animation clips, animation controller, trigger animations from Script
- Camera follower movement with offset
- GameObject generation using Instantiate()
- Background generation call calculations based on reference point so that it doesn't unnecessarily keep on generating the object
- Use of Random.Range() to give randomised position for pipe generation
- Use of InvokeRepeating() for interval based continuous generation
- Use of Destroy() to destroy out of screen in-behind objects
- Basic use of PlayerPrefs
- Basic use of Enums