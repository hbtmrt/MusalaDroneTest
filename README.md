# Musala Drones
## The trusted drones to deliver your medication items.

[![N|Solid](https://www.musala.com/wp-content/themes/musalasoft/dist/assets/img/logo_musala_green.png)](https://www.musala.com/)

## Projects
1. Web API
2. Scheduled Job

## Web API
- Project Name : MusalaDrones.WebApi
- Dependencies
-- MusalaDrones.Business - All the business logic goes here
--MusalaDrones.Business.Data - all the data related logic goes here
--MusalaDrones.Business.Core - common information for the project.

### Endpoints
- POST /droneoperator/drone 
-- Register a drone
- POST /droneoperator/drone/{id}/load
-- Load medication items to a drone
-- {id} is the drone id.
- GET /droneoperator/drone/{id}/medicationitems
-- Get medication items loaded in a drone
-- {id} is the drone id.
- GET /droneoperator/drone/available
-- Get available drones
- GET /droneoperator/drone/{id}/batterylevel
-- Get the battery level of the drone.
-- {id} is the drone id.

## Assumptions
- The maximum number of drones that the system can register is 10.
- The drone is always in IDLE state when registering.
- When retrieving available drones, it will not check only the battery level(battery level should be greater than 25), it will check whather the drone is in IDLE state.
- The scheduled job runs every 10 minutes.
- The project uses EF Core in-memory cache to store data, and it is not a distributed cache. Therefore the data created in the Web API project cannot be retreived in the scheduled job project. (since in-memory cache cannot be shared across processes.)
- Load drones endpoint - The medicaion items should exist in the system. Hence it has introduced as list of integer parameter in the method.

## Special Notes
- The fake data is created when each project loads.
- Most of the validation has been excecuted with the custom data validations. 
-- EnumValidateExistsAttribute
Checks if the given value exist in the enum.
-- MedicationCodeAttribute
Checks if the medical code is valid.
-- MedicationNameAttribute
Checks if the medical name is valid.
- Unit Testing has not been written.
- A github action is added (in .github/workflows) to makesure the application builds without any build errors.

## Running the application

### POST /droneoperator/drone

```sh
Json data:
{
    "SerialNumber": "aaxd",
    "Model": 3,
    "WeightLimit": 233,
    "BatteryCapacity": 23,
    "State": 2
}
```

### POST /droneoperator/drone/{id}/load

```sh
Json data:
[2,3]
```
### GET /droneoperator/drone/{id}/medicationitems
```sh
/droneoperator/drone/2/medicationitems
```

### GET /droneoperator/drone/available
```sh
/droneoperator/drone/available
```

### GET /droneoperator/drone/{id}/batterylevel

```sh
/droneoperator/drone/2/batterylevel
```

## Test cases excecuted

### POST /droneoperator/drone
- Successful Register
- Unsuccessful Register
-- If the system has already 10 drones (maximum drones that can be registered)
-- If invalid serial number is entered (having more than 100 characters)
-- If the serial number already exist in the system
-- If invalid model (ex - 5)
-- If invalid weight limit (ex weight limit is greater than 500)
-- If invalid battery percentage (not in range 0-100)
-- If invalid state (ex - 6)

### POST /droneoperator/drone/{id}/load
- Successful request
- Unsuccessful request
-- If the drone not found
-- If the battery level is below 25
-- If one or more medicatin items are not found in the system
-- if the total weight of the medication items are greater than the drone weight limit

### GET /droneoperator/drone/{id}/medicationitems
- Successful request
- Unsuccessful request
-- If the drone not found

### GET /droneoperator/drone/available
- Successful request

### GET /droneoperator/drone/{id}/batterylevel
- Successful request
- Unsuccessful request
-- If the drone not found

