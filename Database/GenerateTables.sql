
CREATE TABLE IF NOT EXISTS users 
(
    id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(30),
    user_name VARCHAR(30) UNIQUE,
    game_stage INT DEFAULT 1,
    score INT DEFAULT 0,
    last_name VARCHAR(30)
);

DELETE FROM intel_reports;
DELETE FROM notifications;
DELETE FROM people_status;
DELETE FROM people;

