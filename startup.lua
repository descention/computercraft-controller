
-- register self with server
func Register(self)
    baseUrl="http://localhost:5000/api/Turtles"
    data="{\"id\":" .. os.getComputerID() .. ""}"
    headers={["Content-Type"] = "application/json", accept = "text/plain"}
    local response = http.post(url,data,headers)
    if response then
        print("Registered")
        local sResponse = response.readAll()
        response.close()
        local jResponse = textutils.unserialiseJSON(sResponse)
    else
        print("Failed to register")
    end
endfunc

-- request task

-- inform server of data as found