# Details for test
##REST API for authentication and then calculating Levenshtein Distance between two strings

## Web APP Url
https://gleac.eastus.cloudapp.azure.com/app

## Web API Url 
https://gleac.eastus.cloudapp.azure.com/api Credentials: prashant@gleac.com | pass123

## cURL Call to authenticate the API:

curl --location --request POST 'https://gleac.eastus.cloudapp.azure.com/api/Token'
--header 'Content-Type: application/json'
--data-raw '{ "Email": "prashant@gleac.com", "Password": "pass123" }'

## cURL Call to find string distance:

curl --location --request POST 'https://gleac.eastus.cloudapp.azure.com/api/Distance/'
--header 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJHbGVhY1NlcnZpY2VBY3Rpb25Ub2tlbiIsImp0aSI6ImNiMGQwNTdjLWQ3NTMtNGE0OS1iY2E5LTczNDZmMTc2ODNkMSIsImlhdCI6IjgvMjYvMjAyMCA3OjI2OjUyIFBNIiwiSWQiOiJwcmFzaGFudDE5c2VwIiwiRmlyc3ROYW1lIjoiUHJhc2hhbnQiLCJMYXN0TmFtZSI6IlNpbmdoIiwiRW1haWwiOiJwcmFzaGFudEBnbGVhYy5jb20iLCJleHAiOjE1OTg1MzAwMTIsImlzcyI6IkdsZWFjQXV0aGVudGljYXRpb25TZXJ2ZXIiLCJhdWQiOiJHbGVhY1NlcnZpY2VQb3N0bWFuQ2xpZW50In0.GSPfRyZpdvqiTCg6u6orJEG8bO4qgusajEjSG-qTr08'
--header 'Content-Type: application/json'
--data-raw '{ "Str1" : "HONDA", "Str2" : "HYUNDAI" }'
