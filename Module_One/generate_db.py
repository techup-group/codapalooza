import sqlite3

conn = sqlite3.connect('database.db', check_same_thread=False)
c = conn.cursor()

c.execute('''CREATE TABLE entries
				(volunteer, sleep_location, sleep_location_detail, first_name, last_name, ssn, dob, age,
				gender, hispanic, race, homelessness_duration, shelter_frequency, shelter_months, county_duration,
				homelessness_cause, foster_status, disability_status, disability_type, veteran_status, military_branch,
				military_enter_date, military_exit_date, discharge_type, health_insurance_status, domestic_violence_status,
				felony_status, income_amount, income_type, employment_status, 'homeless_children', 'homeless_adults', family_info,
				survey_time, survey_date, survey_location)''')