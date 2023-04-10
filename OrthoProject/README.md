# Introduction 
This project replaces the existing web-interface for running simulations.  
The underlying AnyLogic simulation and supporting components will remain largely un-touches.  The front end and supporting database will be completely re-written.

# Specification
The following link & password contains folder with Ortho brand standards and the web-app specification.  The specification contains detailed notes on expected functionality of each screen. <br/>
https://mosimtec.egnyte.com/fl/YxVWOsc4gj <br/>
Password: S8DtXFzv <br/>

# Getting Started
The repo is divided into 3 decoupled areas: <br/>
1. web - The front end developed in C# using Blazor & DevExpress
1. businesslogic - The business logic developed in C#.  Key functions called by the front end include processing VISO layout and running the simulaton model.
1. database - Scripts for creating the PostgreSQL database.  As the project progresses, this will be used for update scripts as well.

Users should ensure they have access to appropriate AWS resources to deploy to Elastic Beanstalk and access the RDS PostgreSQL database.
##Link to AWS setup information:
https://mosimtec.egnyte.com/fl/v1lpc6KmU3 <br/> 
Password: VaX2prK7

##Key AWS Assets
Elastic Beanstalk Web Application Name: orthosimweb <br/>
Environment: Orthosimweb-Environment <br/>
EC2 instances: t3.medium and t3.large <br/>
URL: orthosim.us-east-1.elasticbeanstalk.com

# Database Scripting
Database scripts checked into the repository will be to create the database from scratch.  Once the tool is in production, DB scripts for updates will also be stored in the repository.
The process for updating database structure during development will generally be to add fields, tables; etc and then re-generate scripts.
Data will not be scripted into the database, EXCEPT for configuration data, such as the 3 types of simulation runs.

# Moving to Ortho Environment
After the initial development push, this project; including repo, bug tracking, and remaining user stories; will be moved to Orhto environments.  This is developed in a MOSIMTEC environment for speed during the end of the year push.

# AnyLogic Model and Supporting components
The source code for these items is currently on MOSIMTEC's internal TFVC, as they are existing.
Once the project gets closer to being ready to call these components, they will be moved here as either compiled components or their entire source code.  This is TBD.