# InnerCircle.EmailSender
Service for sending emails via smtp

## Email senders
In this service we use several senders ("Google SMTP", "SendGrid") for sending emails to recipients.

## Send Grid
You must have an account with API key that you will use in this app.
If you don't have an account, you can create it [here](https://sendgrid.com/pricing/)

#### Notice: make sure that you don't push your SendGrid credentials in this repo. Otherwise, SendGrid can block your account

## Google SMTP
We use this sender in "Debug" and "Development" mode.  
To use the service, you need to create a password for external applications on your account. To do that check the [link](https://support.google.com/accounts/answer/185833?hl=en).  
Also check an [article](https://support.google.com/mail/answer/7126229?hl=en) to configure Google SMTP.

#### Notice: make sure that you don't push your Gmail SMTP credentials in this repo.

## Launch docker containers

1. Make a copy of the file `docker-compose-example.yml` and call it `docker-compose.yml`

2. Enter options of your email sender in `docker-compose.yml`:

If you use the Google SMTP, fill out the following variables:
- GoogleSmtpOptions__Host
- GoogleSmtpOptions__Port
- GoogleSmtpOptions__FromEmail
- GoogleSmtpOptions__FromPassword

If you use Send Grid, fill out:  
- SendGridOptions__SendGridAPIKey
- SendGridOptions__SenderEmail
- SendGridOptions__SenderName

3. You need to create an internal network for configuring interaction between different back-end services.  
You can do it using the following command in your terminal: `docker network create ic-backend-deb`.  
Note: If you already has this network, skip this step.

4. Execute the command `docker-compose up -d` from source folder
