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

# API Documentation

## Question Endpoints
### `GET` /api/questions

**Query Parameters:**
|Name|Type|Description|Required|
|----|----|-----------|--------|
|page|integer(int32)|Page number for pagination|YES|
|pageSize|integer(int32)|Page size for pagination|YES|
|sortColumn|string|Sorting column("prompt", "answer", "last-modified"); DEFAULT: "AddedTime"|NO|
|sortOrder|string|Sorting order("asc" - DEFAULT, "desc")|NO|
|prompt|string|Question prompt(Includes only questions with containing prompt)|NO|
|quizId|string|Includes only questions with specific quizId|NO|

**Example**:
- Request: `http://localhost:5050/api/questions?page=1&pageSize=2`
- Response:
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

### `POST` /api/questions
**Request Body (application/json):**
``` json
{
  "prompt": "string",
  "answer": "string"
}
```

### `PUT` /api/questions
**Request Body (application/json):**
``` json
{
  "id": {
    "value": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
  },
  "prompt": "string",
  "answer": "string"
}
```

### `DELETE` /api/questions/{questionId}
**questionId** - string(path parameter)

**Example**:
- Request: `http://localhost:5050/api/questions/dbc1ddd1-9359-4ce7-97d1-e74be6591cb1`
- Response: `Status Code 204`

## Quiz Ednpoints

### `GET` /api/quizzes

Returns quizzes data without their questions.

**Query Parameters:**
|Name|Type|Description|Required|
|----|----|-----------|--------|
|page|integer(int32)|Page number for pagination|YES|
|pageSize|integer(int32)|Page size for pagination|YES|
|sortColumn|string|Sorting column("answer", "last-modified"); DEFAULT: "AddedTime"|NO|
|sortOrder|string|Sorting order("asc" - DEFAULT, "desc")|NO|
|title|string|Quiz title(Includes only quizzes containing title string)|NO|

**Example**:
- Request: `http://localhost:5050/api/quizzes?page=1&pageSize=2`
- Response:
```json
[
  {
    "id": {
      "value": "84ca016b-f275-420a-a099-074724b32d70"
    },
    "title": "Kviz 1",
    "addedTime": "2023-08-01T19:56:23.224833",
    "lastModified": "2023-08-01T19:56:23.224839"
  },
  {
    "id": {
      "value": "c54726cd-80b1-4832-87a1-dbbb3a50a5ad"
    },
    "title": "New title",
    "addedTime": "2023-08-02T11:00:23.488648",
    "lastModified": "2023-08-02T11:06:09.623577"
  }
]
```
### `GET` /api/quizzes/{quizId}
**quizId** - string(path parameter)

Returns quiz data with its questions.

**Example**:
- Request: `http://localhost:5050/api/quizzes/84ca016b-f275-420a-a099-074724b32d70`
- Response:
```json
{
  "id": {
    "value": "84ca016b-f275-420a-a099-074724b32d70"
  },
  "title": "Kviz 1",
  "questions": [
    {
      "id": {
        "value": "0c2e36d1-1464-467d-bbb8-7180a2392b07"
      },
      "prompt": "Pitanje 2",
      "answer": "Odgovor 2",
      "addedTime": "2023-08-01T19:54:31.35914",
      "lastModified": "2023-08-01T19:54:31.359155"
    },
    {
      "id": {
        "value": "921f6790-de27-45cc-b1bc-da396997fcce"
      },
      "prompt": "Pitanje 1",
      "answer": "Odgovor 1",
      "addedTime": "2023-08-01T19:54:21.888855",
      "lastModified": "2023-08-01T19:54:21.890091"
    }
  ],
  "addedTime": "2023-08-01T19:56:23.224833",
  "lastModified": "2023-08-01T19:56:23.224839"
}
```


### `POST` /api/quizzes
**Request Body (application/json):**
``` json
{
  "title": "string",
  "questionIds": [
    {
      "value": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }
  ]
}
```

### `PUT` /api/quizzes
**Request Body (application/json):**
``` json
{
  "id": {
    "value": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
  },
  "title": "string",
  "questionIds": [
    {
      "value": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }
  ]
}
```

### `DELETE` /api/quizzes/{quizId}
**quizId** - string(path parameter)

**Example**:
- Request: `http://localhost:5050/api/quizzes/84ca016b-f275-420a-a099-074724b32d70`
- Response: `Status Code 204`
