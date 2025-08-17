# zvoove

GitHub API Case Study

Your team needs a tool to help developers discover trending repositories and understand the popularity of programming languages on GitHub. The tool should provide insights beyond GitHub's standard trending page by implementing a custom ranking algorithm that considers multiple factors.

## Documentation

- 📊 **[Project Progress Report](PROGRESS_REPORT.md)** - Detailed analysis of project completion, time tracking, and performance metrics
- 🚀 **[Installation Guide](INSTALLATION.md)** - Complete setup instructions for development and Docker deployment

## Requirements Discovery

### Challenges

The GitHub API provides no explicit endpoints to request trending repositories or languages.

### Possible Solutions

1. Using the GitHub API to search for recently created repositories

The GitHub API provides an endpoint to search for repositories using various criteria.
A possible solution would be to request repositories since a defined time, ordered by stars. This would result in a response like "New and tranding repositories".
An evaluation of the trending languages could be done on the same data by evaluating the used languages per repository.

2. Scraping of the Trending Page

Automatic scraping of the trending page would give the exact same result as the trending repositories.
In this case the result would be limited to 19 repositories (as of 2025-08-12) and a custom scoring system might not perform well enough.

- https://www.gharchive.org/
- https://cloud.google.com/bigquery/public-data
- Several non commercial GitHub Repositories

### Solution

Using a non commercial, private API may result in sudden outages or changes in availability which could disrupt the service.
GHArchive and BigQuery would need further aggregation as they return hourly data.
Scraping the trending page could provide a more immediate solution, but it comes with its own set of challenges, such as potential changes to the page structure and legal considerations.

As for the limited time that is available for the case study and the objective to demonstrate API discovery, the GitHub API with a custom search query will be used. Therefore an own definition of what constitutes a "trending" repository will be needed.
GitHub rate limitations may impact the ability to retrieve data efficiently for frequent usage so caching strategies will be considered.

For the purpose of this case study, the first 1000 entries returned by the GitHub API will be used.
Therefore no rate limit will be reached and a solid basis to evaluate the trending repositories will be established.

### Definitions

**Trending Repository**:
A repository on GitHub that is newer than 90 days and has gained significant popularity, measured by the number of stars.

**Score**
A numerical representation of a repository's popularity, calculated based on the number of stars, forks, age, last update and open issues

### GitHub API notable Endpoints

GitHub provides three endpoints that can be used for this case study:

1. GET https://api.github.com/repositories
   Listing all repositories in ascending order of their ID. An optional parameter for a starting ID can be provided.
   This is non optimal as reading several pages might be needed which in turn could exceed the rate limit of 60 unauthorized request per hour (see: https://docs.github.com/en/rest/using-the-rest-api/rate-limits-for-the-rest-api?apiVersion=2022-11-28)

2. GET https://api.github.com/rate_limit
   Returns the current rate limit status. This is an useful endpoint to check whether the available rate limit has been replenished after exceeding.

3. GET https://api.github.com/search/repositories
   This endpoints allows the search for repositories using a query syntax with additional parameters for paging and sorting.
   As this would yield far better results than the repository list endpoint, this is the best choice to access the needed information.

## UI Design

To create a responsive and consistent looking app a ui framework should be used.

1. Angular Material
   Is a free of charge UI component library for Angular applications. It provides a set of reusable and customizable UI components that follow the Material Design guidelines. It is well documented and widely used in the Angular community, making it a good choice for building modern web applications. It supports responsive design out of the box.
   There are no dedicated components for data visualization, which might be a limitation for this project.

2. PrimeNG is a rich UI component library for Angular applications. It offers a wide range of components, including data and data visualization tools like tables, charts and graphs, which can be beneficial for displaying trends and analytics in the application.

3. Syncfusion, KendoUI and DevExtreme offer similiar capabilities as PrimeNG but don't offer a free tier which makes them not suitable for this project.

The best fit for this project is PrimeNG offering out of the box data components and a rich set of UI elements.
Additionally tailwind will be used to provide pre-defined CSS classes for styling the components and ensuring a consistent look and feel across the application.

### Mockups

To create the mockups without loosing time the Stich AI from google was prompted to generate a mobile UI design based on the requirements.
The result does not represent the final design but serves as a starting point for further refinement.

<img src="Assets/ui mock.png" alt="Mock" style="width:60%;" />

## User Stories

### PreRequesites

**Tasks**

1. Create a new solution (5min)
2. BE:Add the backend project to the solution using the default minimal API Template provided by Microsoft (5min)
3. FE: Generate a new angular frontend project using the CLI, remove all unnecessary files and code, add the primeNg package with tailwind css. Consult the PrimeNG documentation for guidance: https://primeng.org/installation and https://primeng.org/tailwind (5min)

Total: 20min

### Story 1 - MVP

**User Story:**

As a software developer who wants to stay informed about the latest trends,  
I want to easily access a curated list of the current trending repositories on GitHub,  
So that I can quickly discover popular projects and explore new technologies.

**Acceptance Criteria:**

Given I open the application,  
When I navigate to the main page,  
Then I should see a list of trending repositories, including key details.

- The list displays 100 trending repositories.
- Each repository entry shows the repository name, description, star count, and primary language.
- The list is sorted by star count in descending order.
- The UI is responsive and works on mobile and desktop devices.
- Loading and error states are handled gracefully (e.g., show a spinner or error message).

**Tasks:**

1. BE: Implement a data service to fetch trending repositories from the GitHub API and cache them for six hours using a in-memory cache. See [Technical Appendix 1](#technical-appendix) for the API endpoint and query parameters. (15min)
2. BE: Add an endpoint to GET the list of trending repositories. The DTO must contain name, description, star count and primary language (5min)
3. FE: Adjust the main component to display a child component and a navigation bar at the top (10min)
4. FE: Create a service to request the list of trending repositories from the API (5min)
5. FE: Create a component to show skeleton animations for a list. This will be used as loading state. (10min)
6. FE: Create a component to display a list entry for a trending repository. This component should show the repository name, description, star count, and primary language. (10min)
7. FE: Create a component to show an error message. This will be used as error state. (10min)
8. FE: Create the component to display the list of trending repositories using the service. Show the skeleton component as loading state during the API call. If an error occurs, display the error component. On success show the list using the component created in step 7. (10min)

Total: 75min

### Story 2 - MVP

**User Story:**

As a software developer who wants to stay informed about the latest technology trends,  
I want to view a list of trending programming languages on GitHub,  
So that I can discover which languages are currently popular and in demand.

**Acceptance Criteria:**

Given I open the application,  
When I navigate to the trending languages section,  
Then I should see a list of programming languages ranked by their current popularity, with relevant metrics such as repository count.

- The list displays all programming languages of the trending repositories.
- Each language entry shows the language name and the number of repositories using it.
- Popularity of a language is determined by the number of stars the repositories have.
- The list is sorted by popularity in descending order.
- The UI is responsive and works on mobile and desktop devices.
- Loading and error states are handled gracefully (e.g., show a spinner or error message).

**Tasks:**

1. FE: Create a signal store in the frontend to cache the last request for repositories. Adjust the repository list component to use the signal store for data retrieval (15min)
2. FE: Create an additional store signal to get the top languages of the cached repositories. Top languages are determined by the number of repositories they are used in. (5min)
3. FE: Create the component to display the list of trending programming languages. Add loading and error states, routing and a navigation item for it (15min).

Total: 35min

### Story 3 - MVP

**User Story:**

As a software developer who is interested in different metrics related to trending repositories,  
I want to view a custom score based on factors like stars, forks, recent activity and issues,  
So that I can better understand the popularity and activity level of each repository.

**Acceptance Criteria:**

Given I view the repository list in the application,  
When I look at the list entries
Then I should see a numerical score that reflects the repository's popularity and activity.

- The score is displayed alongside each repository entry in the list.
- The score is calculated using a formula that takes into account stars, forks, open issues, last update and age.
- The formula uses logarithmic scaling and weights for each factor to ensure a balanced score.

**Tasks:**

1. BE: Create an algorithm that calculates a score for each repository. See [Technical Appendix 2](#technical-appendix) for details (15min)
2. BE: Add a score field to the DTO used in the GET trending repositories endpoint that is calculated using the algorithm. Change the default sort order of the repository list to be based on this score in descending order (5min)
3. FE: Update the repository list entry component to display the custom score for each repository in the list (5min)

Total: 25min

### Story 4

**User Story:**

As a software developer interested in specific topics,
I want to filter the list of trending repositories by keywords or topics,
So that I can quickly discover repositories relevant to my interests and focus my exploration.

**Acceptance Criteria:**

Given I view the repository or language list in the application,
When I look at the top of the page
Then I should see a search bar that enables filtering repositories by keywords or topics.

- When I enter a keyword or topic in the search bar, the repository list updates in real time to show only matching repositories.
- Filtering is case-insensitive and matches against repository names, descriptions, and topics.
- The trending languages list updates to reflect only the languages used in the filtered repositories.
- The search bar is accessible from all main views and is clearly visible at the top of the app.
- If no repositories match the filter, a friendly message is displayed.
- The filter is debounced to avoid excessive API calls or UI updates.

**Tasks:**

1. BE: Add a filter parameter to the endpoint to GET the list of trending repositories (5min)
2. BE: Update the data service and repository service to handle an optional filter when fetching trending repositories. See [Technical Appendix 4](#technical-appendix) for details. (5min)
3. FE: Update the frontend to include a filter in the signal store and repository service for keywords or topics (5min)
4. FE: Create a search bar component and add it to the top of the app to allow users to input keywords or topics for filtering (10min)
5. FE: Create an empty state component and display it, if no repositories match the filter. (5min)

Total: 30min

### Story 5

**User Story:**

As a user with little time
I want to quickly see the division of the various programming languages
So that I can see which languages are currently popular and in demand.

**Acceptance Criteria:**

Given I am viewing the trending languages
When I look at the top of the list
Then I should see a visual representation (e.g., a pie chart or bar graph) showing the distribution of programming languages.

**Tasks:**

1. Create a component to display the visual representation of programming language distribution as ring chart (15min)
2. Integrate the component into the trending languages view before the list (5min)

Total: 20min

### Post Requisites

- Add Docker files for frontend and backend, see [Technical Appendix 5](#technical-appendix) (15min)
- Add installation instructions

## Code of conduct

### General:

- We follow SOLID and Clean Code principles to ensure our code is maintainable, scalable, and easy to understand.
- We prioritize code readability and simplicity, avoiding unnecessary complexity.
- We leverage dependency injection to promote loose coupling and enhance testability.
- We use asynchronous programming to improve performance and responsiveness.

### Backend:

- We design all API endpoints following RESTful best practices, prioritizing simplicity, consistency, and discoverability.
- We provide comprehensive and up-to-date API documentation using OpenAPI, ensuring ease of use for all consumers.
- We maintain a robust suite of unit and integration tests for all components to guarantee reliability and facilitate safe refactoring.
- We define and use Data Transfer Objects (DTOs) to standardize and document the structure of data exchanged between client and server.
- We leverage NSwag to automatically generate TypeScript interfaces from our API specifications, ensuring strong type safety and seamless synchronization between frontend and backend.
- We use ReSharper or Rider to enforce coding standards and automate code formatting.
- We use Response-Caching to optimize performance and reduce unnecessary API calls.

### Frontend:

- We use PrimeNG for our UI components, ensuring a consistent and modern look and feel.
- We use Prettier to automatically format our code and ensure a consistent style across the codebase.
- We use ESLint to enforce coding standards and catch potential errors early in the development process.
- We use Typescript to add static typing to our JavaScript code, improving maintainability and reducing runtime errors.
- We use Angular's Signal-Syntax for managing state and reactivity in our components.
- We apply a mobile first approach to responsive design, ensuring our application is usable on all devices.

## Technical Appendix

### 1. GitHub API Endpoint

Endpoint to use for requesting repositories: `GET https://api.github.com/search/repositories?q=created:<2025-05-14 fork:false&sort=stars&order=desc&per_page=100`

Query parameter explanation:  
created:<{YYYY-MM-DD} - Filters repositories created before this date.  
fork: false - Filters out forked repositories.  
sort: stars - Sorts the results by the number of stars.  
order: desc - Orders the results in descending order.  
per_page: 100 - Limits the number of results returned to 100.

No Authentication is required

For further documentation see: https://docs.github.com/en/rest/search/search?apiVersion=2022-11-28#search-repositories
and: https://docs.github.com/en/search-github/searching-on-github/searching-for-repositories

### 2. Score Algorithm

This repository scoring algorithm combines popularity, activity, and health into a single value.

- Popularity is measured by stars and forks with logarithmic scaling to provide diminishing returns for large values.
- Freshness is calculated from the last update date using a reciprocal log decay, rewarding recent activity.
- Health is measured by the number of open issues, with more issues lowering the score.

Let:

- \( S \) = stars
- \( F \) = forks
- \( I \) = open issues
- \( U \) = days since last update

<img src="Assets/score_algorithm.png" alt="Score Algorithm" style="width:60%;" />

### 3. Query parameters for filtering

in:name - Filters repositories by name.  
in:description - Filters repositories by description.  
in:topics - Filters repositories by topic.

example filtering for "cat": `GET https://api.github.com/search/repositories?q=cat in:topics,in:description,in:name created:<2025-05-14 fork:false&sort=stars&order=desc&per_page=100`

### 4. GitHub Repository

The GitHub repository for this project can be found here: [GitHub Repository](https://github.com/vezixig/zvoove)

### 5. Creation of Docker files

Frontend:  
https://medium.com/@nadir.inab.dev/dockerizing-your-angular-app-a-quick-guide-00a3ecabe419

Backend:  
https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows&pivots=dotnet-9-0#create-the-dockerfile

## Technical Debt

- Missing code documentation
- No unit, integration and e2e tests
- Mixed classes and inline styles
- No explicit handling of the rate limit was added

## Possible Improvements

As the most limiting factor for this case study was time there are several improvements that could be made given more time:

1. Code quality in general

2. Mocks for individual components and views of the UI could be created using Figma. PrimeNg offers a FigmaUI kit that could be leveraged for this purpose. This would also give the possibility to run usability tests and gather feedback early in the design process.

3. The backend could be improved by implementing clean architecture for clear separation and better testing capabilities with a modular monolithic approach to enable future splitting of microservices.

4. The mediator pattern could be introduced to decouple presentation and application layers and improve maintainability.

5. Caching strategies could be enhanced by using hybrid caching with Redis (introduced in .NET 9).

6 . To not run into rate limitations, GitHub Authentication could be added to the Application to let users sign in and increase their rate limits.

7. .NET Aspire could be used as a framework for building and running the application from a single point.

8. End-to-End testing using Playwright could be implemented to ensure the entire application works as intended from the user's perspective.

9. A CI pipeline could be established to automate testing and build processes, ensuring more reliable merges.

10. A component to display repository details could be created, providing users with more information about each repository.

11. During development the GitHub API returned empty results for a short time until working as expected again. This should be investigated further to understand the cause and prevent similar issues in the future.
