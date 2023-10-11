-- ORDERING RESULTS

-- Populations of all states from largest to smallest.
SELECT state_abbreviation, population FROM state

SELECT state_abbreviation, population FROM state
ORDER BY population

SELECT state_abbreviation, population FROM state
ORDER BY  population ASC

SELECT state_abbreviation, population FROM state
ORDER BY  population DESC


-- States sorted alphabetically (A-Z) within their census region. The census regions are sorted in reverse alphabetical (Z-A) order.

SELECT * FROM state
ORDER BY census_region

SELECT * FROM state
ORDER BY census_region DESC, state_name ASC


-- The biggest park by area

SELECT * from park
ORDER BY area DESC

SELECT TOP(1) * from park
ORDER BY area DESC

SELECT TOP(1) * from park
ORDER BY area ASC

SELECT TOP(10) PERCENT * from park
ORDER BY area DESC


-- LIMITING RESULTS

-- The 10 largest cities by populations

SELECT * FROM city

SELECT * FROM city
ORDER BY population DESC

SELECT TOP 10 * FROM city
ORDER BY population DESC


-- The 20 oldest parks from oldest to youngest in years, sorted alphabetically by name.


SELECT TOP 5 * FROM park
ORDER BY date_established ASC

SELECT TOP 5 park_id FROM park
ORDER BY date_established ASC


SELECT * FROM park WHERE 
park_id IN (61, 53,62,44,14)
ORDER BY park_name


SELECT * FROM park WHERE 
park_id IN 
(SELECT TOP 20 park_id FROM park
ORDER BY date_established ASC)
ORDER BY park_name



-- CONCATENATING OUTPUTS

-- All city names and their state abbreviation.
SELECT * FROM city

SELECT city_name + ', ' + state_abbreviation, * FROM city

SELECT city_name + ', ' + state_abbreviation AS Name, * FROM city

SELECT city_name + ', ' + state_abbreviation Name, * FROM city



-- All park names and area


-- The census region and state name of all states in the West & Midwest sorted in ascending order.



-- AGGREGATE FUNCTIONS

-- Average population across all the states. Note the use of alias, common with aggregated values.

SELECT population FROM state

SELECT AVG(population) Average FROM state
SELECT SUM(population) Sum FROM state
SELECT MIN(population) Min, MAX(population) Max FROM state

SELECT COUNT(*) FROM state

SELECT COUNT(census_region) FROM state






-- Total population in the West and South census regions


-- The number of cities with populations greater than 1 million

SELECT  COUNT(*) FROM city
WHERE population > 1000000


-- The number of state nicknames.

SELECT * FROM state

SELECT COUNT(state_abbreviation), COUNT(state_nickname) FROM state




-- The area of the smallest and largest parks.


--DISTINCT

SELECT city_name FROM city
ORDER BY city_name

SELECT DISTINCT city_name FROM city
ORDER BY city_name




-- GROUP BY

-- Count the number of cities in each state, ordered from most cities to least.

SELECT * FROM city

SELECT * FROM city
GROUP BY state_abbreviation

SELECT state_abbreviation FROM city
GROUP BY state_abbreviation

SELECT state_abbreviation AS State, COUNT(*) AS CityCount FROM city
GROUP BY state_abbreviation
ORDER BY CityCount DESC


-- Determine the average park area depending upon whether parks allow camping or not.

SELECT * FROM park

SELECT has_camping, AVG(area) AS AvgArea FROM park
GROUP BY has_camping


-- Sum of the population of cities in each state ordered by state abbreviation.
SELECT * from city

SELECT state_abbreviation, SUM(population) AS Population FROM city
GROUP BY state_abbreviation
ORDER BY state_abbreviation


-- The smallest city population in each state ordered by city population.



-- Miscelleneous

-- While you can use TOP to limit the number of results returned by a query,
-- it's recommended to use OFFSET and FETCH if you want to get
-- "pages" of results.
-- For instance, to get the first 10 rows in the city table
-- ordered by the name, you could use the following query.
-- (Skip 0 rows, and return only the first 10 rows from the sorted result set.)



-- SUBQUERIES (optional)

-- Include state name rather than the state abbreviation while counting the number of cities in each state,


-- Include the names of the smallest and largest parks


-- List the capital cities for the states in the Northeast census region.

