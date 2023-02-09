# InnerCircle.EmailSender
Service for sending emails via smtp

## Send Grid
In this service we use "SendGrid" for sending emails to recipients.
You must have an account with API key that you will use in this app.
If you don't have an account, you can create it here

#### Notice: make sure that you don't push your SendGrid credentials in this repo. Otherwise, SendGrid can block your account

## Launch docker containers

1. Create the docker-compose.yml file in the source folder

2. Enter credentials of your SendGrid account in docker-compose.yml. You have to fill out the following variables:
    - SendGridOptions__SendGridAPIKey
    - SendGridOptions__SenderEmail
    - SendGridOptions__SenderName

3. You need to create an internal network for configuring interaction between different back-end services.  
You can do it using the following command in your terminal: `docker network create ic-backend-deb`.  
Note: If you already has this network, skip this step.

4. Execute the command `docker-compose up -d` from source folder