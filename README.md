# InnerCircle.EmailSender
Service for sending emails via smtp

## Launch docker containers

1. Change the configuration of credits in the docker-compose file
    - SendGridOptions__SendGridAPIKey
    - SendGridOptions__SenderEmail
    - SendGridOptions__SenderName

### Warning
### Don't save changes in the docker-compose file after changing the above written credits

2. You need to create an internal network for configuring interaction between different back-end services.  
You can do it using the following command in your terminal: `docker network create ic-backend-deb`.  
Note: If you already has this network, skip this step.

3. Execute the command `docker-compose up -d` from source folder