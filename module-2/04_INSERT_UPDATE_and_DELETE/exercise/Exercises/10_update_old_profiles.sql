-- 10. For all people born before 1900 whose profile_path does NOT end in ".jpg", set their

UPDATE person
SET home_page = 'No image', profile_path = NULL
WHERE birthday < '1900/01/01' and profile_path NOT LIKE '%.jpg'
