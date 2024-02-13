# RainfallAPI
Project Description: An API which provides rainfall reading data

# Solution Structure (4 projects):
1. RainfallApi (Web API)
2. RainfallApi.Domain
3. RainfallApi.Infrastructure
4. RainfallApi.Testing

# Dependencies:

A. RainfallApi (Web API)

   Projects:
   
   1. RainfallApi.Domain
      
   2. RainfallApi.Infrastructure
      
   Packages:
   1. Swashbuckle.AspNetCore
      
   2. Swashbuckle.AspNetCore.Annotations
      
B. RainfallApi.Domain
   Projects: (none)
   Packages: (none)
C. RainfallApi.Infrastructure
   Projects:
   1. RainfallApi.Domain
D. RainfallApi.Testing
   Projects:
   1. RainfallApi.Infrastructure
   Packages:
   1. Moq
   2. xUnit
   
# How to Run the API Project:
1. Clone the repository
2. Open the Solution using Visual Studio 2022 (latest build)
3. Build and run the RainfallApi project

# Sample Screenshot (Running the API Project)

![image](https://github.com/atloyola/RainfallAPI/assets/20338754/e3a83a25-6450-481f-953b-c8070dfcb5b5)


# How to Run the Test Project:
1. Build RainfallApi.Testing
2. Click/view the Test Explorer from Visual Studio
3. Run All Tests
   
   3.1 MeasureServiceTest
   
   3.2 ReadingServiceTest
   
   3.3 StationServiceTest

# Sample Screenshot (Running the Test Project)

![image](https://github.com/atloyola/RainfallAPI/assets/20338754/e1b6024d-d0cb-4adb-8820-07de53f35b03)

