-- INNER JOIN

-- Write a query to retrieve the name and state abbreviation for the 2 cities named "Columbus" in the database

SELECT * FROM city;

SELECT * FROM city
WHERE city_name = 'Columbus';



-- Modify the previous query to retrieve the names of the states (rather than their abbreviations).

SELECT * FROM city
JOIN state ON  state.state_abbreviation = city.state_abbreviation
where city_name = 'Columbus'

SELECT city_name, state_name FROM city
JOIN state ON  state.state_abbreviation = city.state_abbreviation
where city_name = 'Columbus'


SELECT city_name, state_name, state.population AS StatePopulation, * FROM city
INNER JOIN state ON  state.state_abbreviation = city.state_abbreviation
where city_name = 'Columbus'


-- Write a query to retrieve the names of all the national parks with their state abbreviations.
-- (Some parks will appear more than once in the results, because they cross state boundaries.)

SELECT * FROM park;

SELECT * FROM park
JOIN park_state ON park_state.park_id = park.park_id

SELECT park_name, state_abbreviation FROM park
JOIN park_state ON park_state.park_id = park.park_id




-- The park_state table is an associative table that can be used to connect the park and state tables.
-- Modify the previous query to retrieve the names of the states rather than their abbreviations.

SELECT park_name, park_state.state_abbreviation, state.* FROM park
JOIN park_state ON park_state.park_id = park.park_id
JOIN state ON state.state_abbreviation = park_state.state_abbreviation

SELECT park_name, state_name FROM park
JOIN park_state ON park_state.park_id = park.park_id
JOIN state ON state.state_abbreviation = park_state.state_abbreviation


-- Modify the previous query to include the name of the state's capital city.

SELECT park_name, state_name, capital FROM park
JOIN park_state ON park_state.park_id = park.park_id
JOIN state ON state.state_abbreviation = park_state.state_abbreviation

SELECT park_name, state_name, capital, city_name FROM park
JOIN park_state ON park_state.park_id = park.park_id
JOIN state ON state.state_abbreviation = park_state.state_abbreviation
JOIN city ON city.city_id = state.capital


-- Modify the previous query to include the area of each park.

SELECT park_name, state_name, city_name, park.area FROM park
JOIN park_state ON park_state.park_id = park.park_id
JOIN state ON state.state_abbreviation = park_state.state_abbreviation
JOIN city ON city.city_id = state.capital

SELECT park_name, state_name, city_name, p.area FROM park p
JOIN park_state ps ON ps.park_id = p.park_id
JOIN state s ON s.state_abbreviation = ps.state_abbreviation
JOIN city c ON c.city_id = s.capital

-- Write a query to retrieve the names and populations of all the cities in the Midwest census region.

SELECT * FROM state
WHERE census_region = 'Midwest'

SELECT * FROM state
JOIN city ON city.state_abbreviation = state.state_abbreviation
WHERE census_region = 'Midwest'

SELECT city_name, city.population FROM state
JOIN city ON city.state_abbreviation = state.state_abbreviation
WHERE census_region = 'Midwest'


-- Write a query to retrieve the number of cities in the city table for each state in the Midwest census region.

SELECT * FROM state
JOIN city ON city.state_abbreviation = state.state_abbreviation
WHERE census_region = 'Midwest'


SELECT city.state_abbreviation, count(*) FROM state
JOIN city ON city.state_abbreviation = state.state_abbreviation
WHERE census_region = 'Midwest'
GROUP BY city.state_abbreviation

-- Modify the previous query to sort the results by the number of cities in descending order.

SELECT city.state_abbreviation, count(*) Count FROM state
INNER JOIN city ON city.state_abbreviation = state.state_abbreviation
WHERE census_region = 'Midwest'
GROUP BY city.state_abbreviation
ORDER BY Count DESC


-- LEFT JOIN

-- Write a query to retrieve the state name and the earliest date a park was established in that state (or territory) for every record in the state table that has park records associated with it.
SELECT * FROM state

SELECT * FROM park_state
JOIN park ON park.park_id = park_state.park_id

SELECT state_abbreviation, MIN(date_established) FROM park_state
JOIN park ON park.park_id = park_state.park_id
GROUP BY state_abbreviation



SELECT state_name, MIN(date_established) FROM state
JOIN park_state ON park_state.state_abbreviation = state.state_abbreviation
JOIN park ON park.park_id = park_state.park_id
GROUP BY state.state_abbreviation, state.state_name

SELECT state_name, MIN(date_established) FROM state
LEFT OUTER JOIN park_state ON park_state.state_abbreviation = state.state_abbreviation
LEFT OUTER JOIN park ON park.park_id = park_state.park_id
GROUP BY state.state_abbreviation, state.state_name

SELECT state_name, MIN(date_established) FROM state
LEFT JOIN park_state ON park_state.state_abbreviation = state.state_abbreviation
LEFT JOIN park ON park.park_id = park_state.park_id
GROUP BY state.state_abbreviation, state.state_name

-- Modify the previous query so the results include entries for all the records in the state table, even if they have no park records associated with them.



-- UNION

-- Write a query to retrieve all the place names in the city and state tables that begin with "W" sorted alphabetically. (Washington is the name of a city and a state--how many times does it appear in the results?)

SELECT * FROM city;

SELECT * FROM state;


SELECT city_name FROM city;

SELECT state_name FROM state;

SELECT city_name, 'city' FROM city
UNION
SELECT state_name, 'state' FROM state;

-- Modify the previous query to include a column that indicates whether the place is a city or state.



-- MovieDB
-- After running the script to set up the MovieDB database, make sure it is selected in SSMS and confirm it is working correctly by writing queries to retrieve...

-- The names of all the movie genres


-- The titles of all the Comedy movies

