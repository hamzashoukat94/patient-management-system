# patient-management-system
[![.NET](https://github.com/hamzashoukat94/patient-management-system/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hamzashoukat94/patient-management-system/actions/workflows/dotnet.yml)
[![Maintainability][maintainability-url]][code-climate-url]
[![Licence][license-badge]][license-url]

## Docker Setup and Commands
Before proceeding, please ensure that the Docker service is up and running.

To build the Docker container, execute the following command:

```
docker compose build
```
To start the Docker container, use the following command:

```
docker compose up
```
If the Docker container is already running and you wish to stop it, run the following command:

```
docker compose down
```
### Web API 

The web API, constructed based on the principles of Domain-Driven Design (DDD), can be accessed through the port http://localhost:4005.


### Patient SPA (Single Page Application)

You have the ability to add, edit, delete, and view all patients. This functionality can be accessed by using the URL http://localhost:4010.

### Improvement can be made

Here are some improvements that can be made to the system:

- Eliminate the need for AutoMapper by replacing it with a factory method for mapping. This approach avoids the use of reflection and can improve performance.

- Implement JWT token authorization to enhance the security of the system. This will require users to provide a valid token in their requests, ensuring that only authorized individuals can access the system.

- Add unit tests to validate the functionality of the system. Unit tests help identify and fix any bugs or issues in the code, ensuring that it functions as expected and behaves correctly in different scenarios.

- Create a generic repository interface instead of using a specific `IPatientRepository` interface. This allows for more flexibility and reusability across different entities in the system. The generic repository can provide common CRUD (Create, Read, Update, Delete) operations that can be utilized by any entity-specific repositories.

These improvements will enhance the system's performance, security, and maintainability while ensuring that it follows best practices and can be easily tested and extended in the future.

[code-climate-url]: https://codeclimate.com/github/hamzashoukat94/patient-management-system
[maintainability-url]: https://api.codeclimate.com/v1/badges/0e7010940bf861485eff/maintainability
[license-badge]: https://img.shields.io/badge/licence-MIT-blue
[license-url]: LICENSE
