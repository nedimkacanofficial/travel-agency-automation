# Travel-Agency-Automation

The project consists of 3 authorizations. After the project's SQL file is executed, the first personnel is added to the database
If the authority status is selected as 0, admin authority is given. If 1 is selected, regional manager authority is given. If 2 is selected, regional manager authority is given.
Then, the lowest authorized office staff, etc., will be able to log into the system.

To run the project, we must first run the sql file through sql server management. Then it opened
The database name in the section starting with use written on the top line of the sql file is a database with the name written here.
After creating it, you should run it with execute. Now the tables and procedures will be loaded into the database.
Then open the database connection section file project file and enter the file defined in the SqlAccess class.
You will fill in the link sentence according to your own information.

In addition, you can enter your own e-mail address and the address given by Gmail from the e-mail section in MailerController.
After you enter your information with the 3 party key, the mailer section will also become functional.

For weather, you should go to openweather.com and get an api key from there and use WeatherController.
After you write your own API key here, the project will run smoothly.

Project Prepared by

Nedim Kaçan
# University Object Based 1 Course Assignment
