# . Dr. RecordAssist API

### Connections

By default, this service starts up on port 8085 and accepts cross-origin requests from `*`.

#### Postgres

This server requires that you have Postgres installed and running on the default Postgres port of 5432. It requires that you have a database created on the server with the name of `postgres`
- Your username should be `postgres`
- Your password should be `root`

#### Postman Collection
https://www.getpostman.com/collections/9378308ae2ee2020163d

#### Usage  
This project contains endpoints to create, read, update, and delete patients/encounters and validates that information accordingly

#### Testing 
Testing is done on each encounter and patient endpoint, to run all tests open test explorer and click 'run all tests' 

#### Swagger
To run swagger run the API and run with this link http://localhost:8085/index.html if this link does not work make sure localhost is the same port as your API