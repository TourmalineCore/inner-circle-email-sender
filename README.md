# InnerCircle.EmailSender
Service for sending emails via smtp

## Send Grid
In this service we use "SendGrid" for sending emails to recipients.
You must have an account with API key that you will use in this app.
If you don't have an account, you can create it here

#### Notice: make sure that you don't push your SendGrid credentials in this repo. Otherwise, SendGrid can block your account

## Google SMTP
For a temporary replacement, we use "Google SMTP".
Help for setting up gmail mail
https://support.google.com/mail/answer/7126229?hl=ru
To use the service, you need to create a password for external applications on your account
https://support.google.com/accounts/answer/185833?hl=ru

#### Notice: make sure that you don't push your Gmail SMTP credentials in this repo.

## Launch docker containers

1. Create the docker-compose.yml file in the source folder

2. Enter credentials of your SendGrid account in docker-compose.yml. You have to fill out the following variables:
    - SendGridOptions__SendGridAPIKey
    - SendGridOptions__SenderEmail
    - SendGridOptions__SenderName
    - GmailOptions__Host
    - GmailOptions__Port
    - GmailOptions__FromEmail
    - GmailOptions__FromPassword

3. You need to create an internal network for configuring interaction between different back-end services.  
You can do it using the following command in your terminal: `docker network create ic-backend-deb`.  
Note: If you already has this network, skip this step.

4. Execute the command `docker-compose up -d` from source folder