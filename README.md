# TASK-CLI PROJECT

https://roadmap.sh/projects/task-tracker

# Task Tracker

**Task Tracker** is a project used to track and manage your tasks. In this project, you will build a simple command line interface (CLI) to track what you need to do, what you have done, and what you are currently working on. This project will help you practice your programming skills, including working with the filesystem, handling user inputs, and building a simple CLI application.

## Requirements

The application should run from the command line, accept user actions and inputs as arguments, and store the tasks in a JSON file. The user should be able to:

- Add, update, and delete tasks.
- Mark a task as in progress or done.
- List all tasks.
- List all tasks that are done.
- List all tasks that are not done.
- List all tasks that are in progress.

## Constraints

- You can use any programming language to build this project.
- Use positional arguments in the command line to accept user inputs.
- Use a JSON file to store the tasks in the current directory.
- The JSON file should be created if it does not exist.
- Use the native filesystem module of your programming language to interact with the JSON file.
- Do not use any external libraries or frameworks to build this project.
- Ensure to handle errors and edge cases gracefully.

## Example Usage

The list of commands and their usage is given below:

```
# Adding a new task
dotnet run task-cli add "Buy groceries"

# Updating and deleting tasks
dotnet run task-cli update 1 "Buy groceries and cook dinner"
dotnet run task-cli delete 1

# Marking a task as in progress or done
dotnet run task-cli mark-in-progress 1
dotnet run task-cli mark-done 1

# Listing all tasks
dotnet run task-cli list

# Listing tasks by status
dotnet run task-cli list done
dotnet run task-cli list todo
dotnet run task-cli list in-progress
```

## Task Properties

Each task should have the following properties:

- **id**: A unique identifier for the task.
- **description**: A short description of the task.
- **status**: The status of the task (`todo`, `in-progress`, `done`).
- **createdAt**: The date and time when the task was created.
- **updatedAt**: The date and time when the task was last updated.

Make sure to add these properties to the JSON file when adding a new task, and update them accordingly when updating a task.

## Getting Started

Here are a few steps to help you get started with the Task Tracker CLI project:

### 1. Set Up Your Development Environment
- Choose a programming language you are comfortable with (e.g., Python, JavaScript, etc.).
- Ensure you have a code editor or IDE installed (e.g., VSCode, PyCharm).

### 2. Project Initialization
- Create a new project directory for your Task Tracker CLI.
- Initialize a version control system (e.g., Git) to manage your project.

### 3. Implementing Features
- Start by creating a basic CLI structure to handle user inputs.
- Implement each feature one by one, ensuring to test thoroughly before moving to the next. For example:
  - Implement adding task functionality first.
  - Next, implement listing tasks.
  - Then, implement updating tasks, marking as in progress, etc.

### 4. Testing and Debugging
- Test each feature individually to ensure they work as expected. 
- Look at the JSON file to verify that the tasks are being stored correctly.
- Debug any issues that arise during development.

### 5. Finalizing the Project
- Ensure all features are implemented and tested.
- Clean up your code and add comments where necessary.
- Write a good README file on how to use your Task Tracker CLI.
