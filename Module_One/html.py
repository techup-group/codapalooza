#!/usr/bin/env python
# Items to fill in HTML templates

#The "general information" inputs on the index page
# see index.html to see how these are rendered
#
# Types of questions.
# - Checkboxes (checkbox)
# - Radio buttons (radio)
# - Text entry (text)
# -
#

index_general_inputs = [
	{
		"topic": "Qualification Questions",
		"glyphicon": "glyphicon-thumbs-up",
		"id": "qualification_questions",
		"questions": [
			{
				"label": "Have you completed this survey earlier today?",
				"type": "radio",
				"id": "completed_survey",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"Yes"},
							{"label":"No"}
					  	]
					}
				]		
			},
			{
				"label": "Are you currently homeless?",
				"type": "radio",
				"id": "currently_homeless",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"Yes"},
							{"label":"No"}
					  	]
					}
				]			
			},
			{
				"label": "Where did you stay last night?",
				"id": "where_stay_last",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"Place not meant for habitation (car, street, abandoned building, etc.)","type":"radio"},
							{"label":"Hotel/Motel paid for by an agency or organization","type":"radio"},
							{"label":"Psychiatric facility","type":"radio"},
							{"label":"Substance abuse treatment facility","type":"radio"},
							{"label":"Hospital","type":"radio"},
							{"label":"Jail, prison, detention facility","type":"radio"},
					  	]
					},
					{"label":"Transitional Housing", "type":"text"},
					{"label":"Emergency shelter", "type":"text"}
				]				
			}			
		]
	},
	{
		"topic": "Survey Questions",
		"glyphicon": "glyphicon-info-sign",
		"id": "general_questions",
		"questions": [
			{
				"label":"Please tell me your first name:", 
				"type":"text",
				"id":"first_name",
			},
			{
				"label":"Please tell me the first 3 letters of your last name:",
				"id":"last_name",
				"type":"text"
			},
			{ 	"label":"Last 4 of your SSN:", 
				"id":"ssn",
				"type":"text" 
			},
			{
				"label":"What is your date of birth?",
				"type":"text",
				"id":"dob"    
			},
			{
				"label":"What is your age?",
				"type":"text",
				"id":"age"		    
			},			
			{
				"label":"Are you:",
				"type":"radio",
				"id":"gender",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{ "label":"Male"},
							{ "label":"Female"},
							{ "label":"Transgender M to F" },
							{ "label":"Transgender F to M"}
					  	]
					}
				]		    
			},
			{
				"label":"Are you Hispanic or Latino?",
				"type":"radio",
				"id":"hispanic",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"Yes"},
							{"label":"No"}
					  	]
					}
				]		    
			},
			{
				"label": "What is your race?",
				"id":"race",
				"type": "checkbox",
				"inputs": [
					{"label":"American Indian/Alaskan Native"},
					{"label":"Asian"},
					{"label":"Black/African American"},
					{"label":"Native Hawaiian/Other Pacific Islander"},
					{"label":"White"},
					{"label":"Other"}
			  	]
			},
			{
				"label": "How long have you been in this episode of homelessness?",
				"type": "radio",
				"id":"homelessness_duration",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"1 week or less"},
							{"label":"more than 1 week, but less than 1 month"},
							{"label":"1 - 3 months"},
							{"label":"more than 3 months, but less than 1 year"},
							{"label":"1 year or longer"}
					  	]
					}
				]
			},
			{
				"label": "How many times have you been on the streets, Emergency Shelter, or Safe Haven in the past three years including today?",
				"id":"shelter_frequency",
				"type": "radio",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
			  		        {"label":"Never in the 3 years"},
							{"label":"One Time"},
							{"label":"Two Times"},
							{"label":"Three Times"},        
							{"label":"Four or More Times"}
					  	]
					}
				]
	   		},
			{
				"label": "Total number of months you have been homeless on the street, Emergency Shelter, or Safe Haven in the past three years?",
				"type": "text",
				"id":"shelter_months",
			},
			{
				"label": "How long have you been staying in Hillsborough County?",
				"type": "radio",
				"id":"county_duration",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"1 week or less"},
							{"label":"More than 1 week, but less than 1 month"},
							{"label":"More than 1 week, but less than 1 month"},
							{"label":"1 to 3 months"},
							{"label":"More than 3 months, but less than 1 year"},
							{"label":"1 year or longer"}
					  	]
					}
				]			
			},
			{
				"label": "What is the primary cause of your homelessness?",
				"id":"homelessness_cause",
				"type": "radio",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"Employment/financial reasons"},
							{"label":"Family problems"},
							{"label":"Recent immigration"},
							{"label":"Housing issues"},
							{"label":"Natural/other disasters"},
							{"label":"Medical/disability problems"},
							{"label":"Other"}
					  	]
					}
				]
			},
			{
				"label": "Were you ever in foster care as a child?",
				"id":"foster_status",
				"type": "radio",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"Yes"},
							{"label":"No"}
					  	]
					}
				]		    
			},
			{
				"label": "Do you have a disabling condition?",
				"type": "radio",
				"id":"disability_status",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"Yes"},
							{"label":"No (If No, skip next question)"}
					  	]
					}
				]
			},
			{
				"label": "What type of disabling condition do you have (you may select more than one condition)?",
				"type": "checkbox",
				"id":"disability_type",
				"inputs": [
					{"label":"Physical"},
					{"label":"Developmental"},
					{"label":"Mental health"},
					{"label":"Alcohol Abuse"},
					{"label":"Drug Abuse"},
					{"label":"HIV/AIDS"}
				]		    
			},
			{
				"label": "Have you ever served on Active Duty in the US Military? (If \"No\", skip next question)",
				"type": "radio",
				"id":"veteran_status",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"Yes"},
							{"label":"No"}
					  	]
					}
				]				    
			},
			{
				"label": "What Branch of the Military did you serve?",
				"type": "radio",
				"id":"military_branch",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"Army"},
							{"label":"Air Force"},
							{"label":"Navy"},
							{"label":"Marines"},
							{"label":"Coast Guard"}
					  	]
					}
				]		    
			},
	
			{
				"label": "What date did you enter the service? (Month/Year)",
				"type": "text",
				"id":"military_enter_date",
			},
		
			{
			"label": "What date did you exit the service? (Month/Year)",
				"type": "text",
				"id":"military_exit_date",
			},
			{
				"label": "What type of discharge did you receive?",
				"id":"discharge_type",
				"type": "radio",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"Honorable"},
							{"label":"Dishonorable"},
							{"label":"General"},
							{"label":"Other than honorable"},
							{"label":"Bad conduct"},
							
					  	]
					},
					{"label":"Other", "type":"text"}
				]
			},
			{
				"label": "Are you covered by Health Insurance?",
				"id":"health_insurance_status",
				"type": "radio",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"Yes"},
							{"label":"No"}
					  	]
					}
				]
			},	
			{
				"label": "Are you a domestic violence victim/survivor?",
				"id":"domestic_violence_status",
				"type": "radio",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"Yes"},
							{"label":"No"}
					  	]
					}
				]
			},			
			{
				"label": "Have you ever been charged with a felony?",
				"id":"felony_status",
				"type": "radio",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"Yes"},
							{"label":"No"}
					  	]
					}
				]
			},			
			{
				"label": "Do you receive any income?",
				"id":"income_type",
				"inputs": [
					{ 
						"type": "radio_group",
					  	"inputs": [
							{"label":"Yes  (If yes, check all sources that apply)", "type":"radio"},
							{"label":"No Income", "type":"radio"},
						
					  	]
					},
					{"label":"Earned income", "type":"checkbox"},
					{"label":"Alimony", "type":"checkbox"},
					{"label":"SSA retirement", "type":"checkbox"},
					{"label":"VA Disability Pension (NON-service connected)", "type":"checkbox"},
					{"label":"SSI", "type":"checkbox"},
					{"label":"Workers' Comp", "type":"checkbox"},
					{"label":"Pension/Retirement Income", "type":"checkbox"},
					{"label":"TANF", "type":"checkbox"},
					{"label":"VA Disability Comp (Service Connected)", "type":"checkbox"},
					{"label":"SSDI", "type":"checkbox"},
					{"label":"Private disability insurance", "type":"checkbox"},
					{"label":"Unemployment", "type":"checkbox"},
					{"label":"Child support", "type":"checkbox"},
					{"label":"SSDI", "type":"checkbox"},
					{"label":"Amount $ /month (Gross)", "type":"text"},
					{"label":"Other source", "type":"text"}
				]			    
			},
			{
				"label": "How many other Adult family members are homeless with you now?",
				"type": "text",
				"id":"homeless_adults",
			},
			{
				"label": "How many other Children family members are homeless with you now?",
				"type": "text",
				"id":"homeless_children",
			}		
		]
	}
]

