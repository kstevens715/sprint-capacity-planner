# sprint-capacity-planner

## Running Locally
To run locally, three things have to be started up:
1. ElasticSearch - This can be done with `docker-compose up -d` in the project's root directory.
2. Frontend
```
cd ScpClient
vue ui
# Now, in the page that opens run the "serve" task.
```
3. Backend - This is done by debugging (F5) in VSCode.

## Data Points
This is for me to think through the data that will need to be collected and/or calculated.

Average/historical/target velocity (readonly, calculated)
Total sprint developer days (readonly, calculated)
Sprint developer days before FF (readonly, calculated)
Total Sprint Capacity (readonly, calculated)
Sprint Capacity Before FF (readonly, calculated)