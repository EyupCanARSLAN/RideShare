# Version2 New Features

At this version, <b>ServiceAggrigators</b> added under Service Tier to aggregate per services function.

I can give an example this situation  like this;

In traditaional N Tier Architecture, a service consist of many public class.  In the below, you can see that
TripService consist of many public and private class. 

![image](https://github.com/EyupCanARSLAN/RideShare/assets/22656439/e00929de-8ffc-4edf-a64a-28b19c7696e4)

This structure can be very complex when project begin to grow. 

I implement Service Aggregator to fix this problem. According to this idea this service's each public class can be moved to separate class and cs file. 

For example in the given example at above ; 

I divided each public class to a different .cs file and I used "ITripServiceAggrigator" in controller side.

![image](https://github.com/EyupCanARSLAN/RideShare/assets/22656439/4dae3bb8-fe50-4c97-a6c1-251c0f7c9784)
<br><br>
And I aggregate  this services under ServiceAggregator via interfaces and dependency injection like below.
<br><br>
![image](https://github.com/EyupCanARSLAN/RideShare/assets/22656439/c01c72ec-473d-4142-99fa-ffd610386ed8)




# RideShare

You can create database with Running <b>"Migration.bat"</b> that is under <b> "Domain" </b> Folder. Alternativly you can executre <b>"RideShare_EyupCan_Db.sql" </b>

You can find descriptions to use program and sample usage in <b>Swagger </b>. Also <b>RideShare.postman_collection.json</b>  contains sample service call

# Missing Part At This Application
<ul>
<li>System can be dockerized. SqlServer and Dotnet image used to works on linux via docker.</li>
<li>String message can be moved to a resource file or can be designed as a constant variable in a seperate class.</li>
<li>UnitOfWork and Generic Repository can be used to manage transiction and rollback scenerio.</li>
<li>This system designed according to data-centric approaches. May can be designed as domain-centric aproaches.</li>
</ul>

# RideShare City Plan
 
In the below I shared basic city plan. I designed the algorithm  according to this plan.

![RideShare_CityPlan](https://github.com/EyupCanARSLAN/RideShare/assets/22656439/9c801ca4-6436-4bc2-aad2-ea2f95e8eabf)
