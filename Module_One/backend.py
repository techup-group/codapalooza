#!/usr/bin/env python
from flask import Flask, request, render_template, redirect, url_for, flash
import sqlite3
import flask, jinja2
import sys, json, os
import html

# ---------------------------------------------------------------------------- #
# connect database
conn = sqlite3.connect('database.db', check_same_thread=False)

# create cursor
c = conn.cursor()

# ---------------------------------------------------------------------------- #
# Flask Application
app = Flask("THHI Homeless PIT Survey", static_url_path = "")
app.secret_key = "roflmao"

#
# Expected fields
FIELDS = ['volunteer', 'sleep_location', 'sleep_location_detail', 'first_name', 'last_name', 'ssn', 'dob', 'age',
				'gender', 'hispanic', 'race', 'homelessness_duration', 'shelter_frequency', 'shelter_months', 'county_duration',
				'homelessness_cause', 'foster_status', 'disability_status', 'disability_type', 'veteran_status', 'military_branch',
				'military_enter_date', 'military_exit_date', 'discharge_type', 'health_insurance_status', 'domestic_violence_status',
				'felony_status', 'income_amount', 'income_type', 'employment_status', 'homeless_children', 'homeless_adults', 'family_info',
				'survey_time', 'survey_date', 'survey_location']

# ---------------------------------------------------------------------------- #
# Routing (wiring)

#Root page, shows the main input form and initial data
@app.route('/', methods=['GET'])
def index():
	return render_template("index.html", general_inputs=html.index_general_inputs)

#The route to POST to when a user fills out the data in index.html
@app.route('/submit', methods=['POST'])
def submit_form():
	print request.form

	# create first part of sqlite execute string
	insert_str = "INSERT INTO entries VALUES ("

	# create INSERT string using form data
	for field in FIELDS:
		data = ""
		if field in request.form:
			data = request.form[field]
		insert_str += '"' + str(data) + '",'

	# replace last , with ) to close statement
	insert_str = insert_str[:-1] + ')'

	print "\nsqlite INSERT string: " + insert_str + "\n"

	# bools to check properly filled out form
	name_filled = not (request.form["first_name"] == "")
	gender_filled = ("gender" in request.form)

	print name_filled
	print gender_filled

	# execute insert string
	if name_filled or gender_filled:
		c.execute(insert_str)
	
	# save and exit database connection
	conn.commit()

	return redirect('/')

# ---------------------------------------------------------------------------- #

if __name__ == '__main__':
    app.debug = True
    app.run(debug=True, host='0.0.0.0', port=5000)
    conn.close()

