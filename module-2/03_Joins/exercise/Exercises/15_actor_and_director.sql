-- 15. The title of the movie and the name of director for movies where the director was also an actor in the same movie.
-- Order the results by movie title (A-Z)
-- (73 rows)
SELECT title, person_name

FROM movie
JOIN movie_actor ON movie.movie_id = movie_actor.movie_id 
JOIN person ON movie_actor.actor_id = person.person_id
WHERE person_id = director_id

ORDER BY title


--SELECT DISTINCT person_name, title

--FROM person
--JOIN movie_actor ON person.person_id = movie_actor.actor_id 
--JOIN movie ON movie_actor.movie_id = person.person_id AND person_id = director_id

--ORDER BY title, person_name



