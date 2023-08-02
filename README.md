# Enterwell Quiz API

## Introduction
The Quiz Maker API is a .NET web application designed to support the creation and management of quizzes. It enables users to create, edit, and delete quizzes, as well as export them in various formats. This API serves as the backend for Quiz Maker application.

## Functional Requirements
The Quiz Maker API supports the following functionality:
- **Fetch all created quizzes:** Retrieve a list of all created quizzes without detailed question information.
- **Create a new quiz:** Allows users to create a new quiz by providing the quiz title and a list of questions. The API supports reusing questions from previously created quizzes.
- **Edit a quiz:** Enables users to modify the title and questions of an existing quiz. Before editing, users are able to view a specific quiz and its associated questions.
- **Delete a quiz:** Provides functionality to delete a quiz. When a quiz is deleted, its associated questions remain in the system for future use.
- **Export a quiz:** Supports exporting a quiz to a CSV file format. The API is designed in a way that allows adding new exporters for different file types in the future.

## Non-functional Requirements
- The Quiz Maker API is developed using .NET Framework version >= 4.5, including newer versions >= 5.
- Communication with the database is implemented using **Entity Framework** with the **Code First approach**.
- Exporters and their dynamic loading are implemented using the **Managed Extensibility Framework** (MEF).
- The API is thoroughly documented to ensure easy understanding and maintenance.

## API Documentation
### Quiz Ednpoints


### Question Endpoints
#### `GET` /api/questions

Query Parameters:
|Name|Type|Description|Required|
|----|----|-----------|--------|
|page|integer(int32)|Page number for pagination|YES|
|pageSize|integer(int32)|Page size for pagination|YES|
|sortColumn|string|Sorting column("prompt", "answer", "last-modified"); DEFAULT: "AddedTime"|NO|
|sortOrder|string|Sorting order("asc" - DEFAULT, "desc")|NO|
|prompt|string|Question prompt(Includes only questions with containing prompt)|NO|
|quizId|string|Includes only questions with specific quizId|NO|

Example:
Request: `http://localhost:5050/api/questions?page=1&pageSize=2`
Response:
```json
[
  {
    "id":{"value":"921f6790-de27-45cc-b1bc-da396997fcce"},
    "prompt":"Pitanje 1",
    "answer":"Odgovor 1",
    "addedTime":"2023-08-01T19:54:21.888855",
    "lastModified":"2023-08-01T19:54:21.890091"
  },
  {
    "id":{"value":"0c2e36d1-1464-467d-bbb8-7180a2392b07"},
    "prompt":"Pitanje 2",
    "answer":"Odgovor 2",
    "addedTime":"2023-08-01T19:54:31.35914",
    "lastModified":"2023-08-01T19:54:31.359155"
  }
]
```
