REST Controllers and Services
=============================
## Overview

Small RESTful API that simulates a backend for a quiz-like application. Data will be stored in a postgreSQL database and Entity Framework Core will be used to interact with the database. A schema will need to be created r by utilizing the migrations/create-drop API provided by EF Core. 

### EndPoints

- [ ] `GET quiz`
    - Returns all `Quiz` elements

- [ ] `POST quiz`

    Creates a quiz
    - Returns the `Quiz` that it created

- [ ] `DELETE quiz/{quizId}`

    Deletes the specified quiz
    - Returns the deleted `Quiz`

- [ ] `PATCH quiz/{quizId}/rename/{newName}`

    Rename the specified quiz
    - Returns the renamed `Quiz`

- [ ] `PATCH quiz/{quizId}/add`

    Adds a question to the specified quiz
    - Receives a `Question`
    - Returns the modified `Quiz`

- [ ] `DELETE quiz/{quizId}/delete/{questionId}`

    Deletes the specified question from the specified quiz
    - Returns the deleted `Question`
