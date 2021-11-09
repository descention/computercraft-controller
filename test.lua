url="http://localhost:5000/api/Turtles"
data="{\"id\":30}"
headers={["Content-Type"] = "application/json", accept = "text/plain"}
http.post(url,data,headers)