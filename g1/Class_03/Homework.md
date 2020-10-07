# Homework - Class 03

1. Create new WEB API project

2. Add new MoviesController

3. Create static database of Movie (model) containing id, name, genre and duration, artists (list of artist's names)

4. Add GET method that returns all movies

5. Add GET method that returns one movie by id with path variable (route parametar)

6. Add POST method that adds new movie through body. (use FromBody attribute)

7. Add GET method that returns movie by specific name using query parametar

## Bonus
- Add GET method that accepts "id" as path variable and "name" as query parametar. Return all artists from that
  specific movie with names starting as the "name"- the query parametar.
- Add GET method with specific route that returns all movies and if in the header Accept-language is "mk-MK"
  in the response provide a message "Во респонсот се вклучени сите филмови кои ги чуваме во датабаза", otherwise
  in the response provide a message "In the response are included all artists that are stored in the database"