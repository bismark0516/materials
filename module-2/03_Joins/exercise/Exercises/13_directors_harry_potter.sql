-- 13. The directors of the movies in the "Harry Potter Collection", sorted alphabetically.
-- (4 rows)
SELECT DISTINCT person_name
FROM collection
JOIN movie ON movie.collection_id = collection.collection_id 
JOIN person ON person.person_id = movie.director_id
WHERE collection_name = 'Harry Potter Collection'
ORDER BY person_name
