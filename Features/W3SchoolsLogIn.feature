Feature: W3SchoolsLogIn

W3Schools Automation for Login

Background: 
	Given Navigate to W3Schools web page for LonIn
	When  User Navigate to 'Log in' page

@W3Schools
Scenario: TC_Successful_Login
	Given  User enters valid 'dskjfnkjsadfkjkjsad3@gmail.com' as Userid and 'P@ssword1' as Password detail in LogIn Page
	When   User should be successfully logged in
	Then   User close webpage

 @W3Schools
Scenario: TC_Invalid Login Attempt
 Given User enters valid 'dskjfnkjsadfkjkjs@gmail.com' as Userid and 'P@ssword1' as Password detail in LogIn Page
 When   User should be successfully logged in
 Then  An error message 'A user with this email does not exist' should be displayed, and the user should not be logged in
 Then   User close webpage