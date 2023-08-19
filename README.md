# Saga.Orchestrator
SAGA pattern in microservices
Orchestration is used when we need a centralized coordinator that manages all the logic and knows when to communicate with other microservices, what steps to take, or how to roll back. 
The orchestration method in the saga pattern will work best when the logic of the saga is monitored and reviewed by one or two teams. Otherwise, the program codes can look very complex and difficult.

On the other hand, the orchestration method also has benefits for understanding complex workflows. One of the most important of these benefits is having a more regular architecture;
Because microservices will not be connected to each other. Of course, the coordinator must know how to return to the previous stage in case of failure. Therefore, the coordinator must store a log of
events for each flow and perform compensating transactions on each corresponding microservice when performing a rollback.


 In this project, I walked through implementing the Saga Orchestration pattern for managing distributed transactions in ASP.NET Core microservices.
Managing transactions across multiple microservices is a hard problem to solve. The saga pattern was introduced to solve this problem of managing distributed transactions.
For the orchestration pattern, as the name suggests in the orchestration implementation there is a centralized orchestrator.
The orchestrator tells each microservice which operation to perform. And in case of issues, it also sends messages to different microservices for a rollback of transactions.
It manages the state of each task through a state machine.

Pros:

1. Highly scalable logic since individual microservices do not have to talk to each other.

2. No possibility of cyclic dependency between microservices.


run all projects and then call "api/order" in "Saga.Orchestrator" project and can see the order controller collects data from Order Service, Inventory Service, and Notifier Service.


![saga1](https://github.com/zakizadeh/Saga.Orchestrator/assets/11499371/cd1f26d0-59a1-48dd-bf71-ccb5d70075f5)

![saga3](https://github.com/zakizadeh/Saga.Orchestrator/assets/11499371/a6f2334c-e799-405f-957f-92799e754e14)

if one Inventory Service goy error, the order would be deleted.

![saga2](https://github.com/zakizadeh/Saga.Orchestrator/assets/11499371/17a69c3a-e7a4-46ae-ae9e-e1b91c0260d3)

you can see the state machine of the project in following picture :

![saga4](https://github.com/zakizadeh/Saga.Orchestrator/assets/11499371/31be5ea3-f2fa-44db-b009-53e763d80101)
