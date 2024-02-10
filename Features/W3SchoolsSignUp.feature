Feature: W3Schoolssignup

W3Schools Automation for registration page

Background: 
	Given Navigate to W3Schools web page
	When  User is on the 'Sign Up' page


@W3Schools
Scenario: TC_Successful_User_Registration
	Given  User enters valid 'dskjfnkjsadfkjkjsad4@gmail.com' as Userid and 'P@ssword1' as Password details
	 When  User able to enter user FirstName'FirstName', LastName 'LastName' and click on Continue
	 Then  User recieve the verify email in 'dskjfnkjsadfkjkjsad4@gmail.com' as Userid
	 


@W3Schools
Scenario: TC_Existing_User_Validation
	Given User enters valid 'dskjfnkjsadfkjkjsa@gmail.com' as Userid and 'P@ssword1' as Password details
	When  User able to enter user FirstName'FirstName', LastName 'LastName' and click on Continue
	Then  An error message 'Looks like you already have a user' should be displayed, and the registration should not proceed
	

@W3Schools
Scenario: TC_Missing_Required_Fields
	Given User enters valid '' as Userid and 'P@ssword1' as Password details
	When  Appropriate error messages 'Please enter an email' should be displayed, and the registration should not proceed
	

