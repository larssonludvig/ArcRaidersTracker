# ArcRaidersTracker
ArcRaidersTracker is a service that aims to provide information and data regarding the game [Arc Raiders](https://arcraiders.com).

---

## Features
|__Feature__|__Status__|__Description__|
|-|-|-|
|__Recycler__|-|Tool that can be used to view items that can be recycled into a specific material. Functionality by search and list.|
|__Item Tracker__|-|Keeps track of all items needed for quests and workbench upgrades. Aims to make it easier to keep track of needed items.|
|__Workbench__|-|Lists recipes and what can be crafted at different tiers. Source of recipes?|
|__Quests__|-|Information about quests and objectives.|

## Usage

## Development
To start out, a database and API will be hosted on-prem where it is exposed by a domain. This solution may not be sufficient as the project grows, in which it may need to be moved into the cloud. Therefore, the API is to be deployable by a docker container through ASP.NET Core. 

The frontend is not decided on.

## Licence
This project, and all code it contains, are licensed under the [*Apache License*](https://www.apache.org/licenses/LICENSE-2.0).
