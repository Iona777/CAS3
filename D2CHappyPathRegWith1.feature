Feature: D2CHappyPathRegWith1
	In order to enter a D2C Pru App ISA Application with Regular Withdrawal
	As an authorised user
	I want to complete all required data and successfully submit an application with a single investment payment and a regular withdrawal.

@mytagEden
Scenario: Complete D2C application with regular withdrawal and make online card payment successfully
	#Given That I am using file 'JsonDataSourceHappy1.json' for the input data

	Given That the investor is on the the D2C Welcome page
	When  The investor clicks on Continue on the D2C Welcome page
	Then  The D2C Details page should be displayed

#	When The investor enters valid hardcoded data on the D2C Details screen and clicks on the Continue button
	When The user enters valid data in the D2C Details screen using file 'D2C SingleRegWith1.json' and clicks on the Continue button
	Then The D2C Your Details page should be displayed

	#When The investor enters valid hardcoded data in the D2C Your Details screen and clicks on the Continue button
	When The user enters valid data in the D2C Your Details screen using the file 'D2C SingleRegWith1.json' and clicks on the Continue button
	Then The D2C Investment Details page should be displayed

	When The investor enters valid hardcoded data for Single investment on the D2C Investment Details screen and clicks on the Continue button
	Then The D2C Regular Withdrawal page should be displayed

	#When The investor enters valid hardcoded data in the D2C Regular Withdrawl screen for a single fund and clicks on the Continue button
	When The investor enters valid data in the D2C Regular Withdrawal screen for a single fund using the file 'D2C SingleRegWith1.json' and clicks on the Continue button
	Then The D2C Summary page should be displayed

	When The investor clicks on the Continue button in the D2C Summary page 
	Then The D2C Investor Declaration page should be displayed



