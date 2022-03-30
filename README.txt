Author:    Alejandro Serrano
Partner:   None
Date:      10/11/2021
Course:    CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Alejandro Serrano- This work may not be copied for use in Academic Coursework.

Deployed URL:  ec2-3-88-10-165.compute-1.amazonaws.com
Github Page:   https://github.com/uofu-cs4540-fall2021/ps4---new-ta-application-alejandros/tree/PS5-UsersRolesTAUSER

Comments to Evaluators:

  For admin functionality use luisa@utah.edu
  For professor functionality carlos@utah.edu
  For Applicant with completed application use kimjunggi@utah.edu
  For Applicant with incomplete application use juan@utah.edu

  All of them have password 123ABC!@#def

  There were many issues with Github that's the reason the current assignment has many branches. For the latest branch, 
  I utilized a previous build so that I could scaffold with TA User instead of IdenityUser as it would've allowed me to 
  create better functionality for users that have completed or not the application. 

  The final build is on the PS5-UsersRolesTAUSER branch. 

  Another issue is that the deployed website is not loading the Applications database. I don't know the reason for this.
  I've implemented  the two solutions provided in class, but still throws the development error. Nonetheless, the db for 
  users and roles and Sendgrid implementation works well. 

Assignment Specific Write-up:

   For PS5 we utilized the User and Roles functionality with asp net Identity. We scaffolded the appropriate pages in order to have
   applicants register to our page. 
   We seeded new information with admin, professor and applicants. 

Peers Helped:

	none

Peers Consulted:

    Alejandro Rubio - He helped me set up AWS. 

Acknowledgements:

   This tutorial http://www.binaryintellect.net/articles/5e180dfa-4438-45d8-ac78-c7cc11735791.aspx and 
   https://alexcodetuts.com/2019/05/22/how-to-seed-users-and-roles-in-asp-net-core/ were utilized in order to understand
   how to seed into the DB. 

   This tutorial helped me with changing the id of the toggle so that each one has a different functionality
   https://stackoverflow.com/questions/63437758/how-to-change-html-elements-id-value-in-a-for-loop



References:

   1. How to Seed Users and Roles in Asp.Net Core - https://alexcodetuts.com/2019/05/22/how-to-seed-users-and-roles-in-asp-net-core/ 
   2. Seed Users And Roles Data In ASP.NET Core Identity - http://www.binaryintellect.net/articles/5e180dfa-4438-45d8-ac78-c7cc11735791.aspx
   3. How to change HTML element's id value in a for loop -  https://stackoverflow.com/questions/63437758/how-to-change-html-elements-id-value-in-a-for-loop


------------PS6------------
Author:    Alejandro Serrano
Partner:   None
Date:      10/25/2021
Course:    CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Alejandro Serrano- This work may not be copied for use in Academic Coursework.

Deployed URL:  ec2-3-229-253-192.compute-1.amazonaws.com
Github Page:   https://github.com/uofu-cs4540-fall2021/ps4---new-ta-application-alejandros/tree/PS6-Course

Comments to Evaluators:

  For admin functionality use luisa@utah.edu
  For professor functionality carlos@utah.edu
  For Applicant with completed application use kimjunggi@utah.edu
  For Applicant with incomplete application use juan@utah.edu

  All of them have password 123ABC!@#def

  The main issue was the static IP. Followed instructions provided by Prof. Germain, but still couldn't get Google authentication to work on EC2 instance.

  Remade Home Page so that it's more user friendly. 

Assignment Specific Write-up:

   For PS6 we created a model for the courses. Admin can add notes. 

Peers Helped:

	none

Peers Consulted:

    none

References:
	
	N/A

	------------PS8------------
Author:    Alejandro Serrano
Partner:   None
Date:      11/21/2021
Course:    CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Alejandro Serrano- This work may not be copied for use in Academic Coursework.

Deployed URL:  N/A
Github Page:   https://github.com/uofu-cs4540-fall2021/ps4---new-ta-application-alejandros/tree/PS8-Avail

Comments to Evaluators:

  The following application handles availability from a logged in user. When user enters their profile, 
  they will see their previous selections upon loading of the page. 

  Spinner was not implemented because aplication automatically saves after each selection. 

  User u0000000:
  email: kimjunggi@utah.edu
  pass: 123ABC!@#def

  The name of the database for the availability application is PS8-Avail
  The name for the application for users and roles is PS4-TAApplication

Assignment Specific Write-up:

	The following application handles availability from a logged in user. 
   
Peers Helped:

	none

Peers Consulted:

    none

References:
	
	Getting key from value - https://www.geeksforgeeks.org/how-to-get-a-key-in-a-javascript-object-by-its-value/
	Using PIXI.js - https://pixijs.io/guides/basics/getting-started.html


	------------PS9------------
Author:    Alejandro Serrano
Partner:   None
Date:      12/9/2021
Course:    CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Alejandro Serrano- This work may not be copied for use in Academic Coursework.

Deployed URL:  ec2-3-229-253-192.compute-1.amazonaws.com
Github Page:   https://github.com/uofu-cs4540-fall2021/ps4---new-ta-application-alejandros/tree/PS9-charts

Comments to Evaluators:



  1. A pie chart was implemented in a second page called PieChart.cshtml. The corresponding JavaScript for this is piechart.js
  2. A second more "fancy" chart was implemented to show the distribution of enrollments through a set amount of time. The chosen data
  represent the peaks in increase of enrollments. The chosen chart was interesting because it allowed to visualize the difference between
  enrollments of Pre-Major classes and Full-Major classes. Of course the data is not complete, but it's a nice visualization. 
  3. An attempt was made to publish to AWS and the ec2 instance is shared on the README. Unfortunately, the EC2 instance is not recognizing the 
  current PS9-Chart-DB database. 
  4. The page that holds the main chart and the "fancy" chart is Charts.cshtml. 
  5. The model can be found at Models. They work based on the foreign key design pattern. These are CourseEnrollments and Enrollment. 
  6. The controller that handles the model is ChartController.cs
  7. Both controller endpoinds are in ChartController. I did not understand what exactly the EnrollmentTrends method is doing from the
  assignment description, but I'm considering the Chart method that returns the view to do something similar. 


Assignment Specific Write-up:

	  The following application graphs a line chart that demonstrates the change in enrollment through time.  
   
Peers Helped:

	none

Peers Consulted:

    none

References:
	
	Highcharts - https://www.highcharts.com/
	Reading a CSV with c#- http://dotnet-tutorials.net/Article/read-a-csv-file-in-csharp