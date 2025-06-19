
CREATE TABLE IF NOT EXISTS users 
(
    id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(30),
    user_name VARCHAR(30) UNIQUE,
    game_stage INT DEFAULT 1,
    score INT DEFAULT 0,
    last_name VARCHAR(30)
);

CREATE TABLE login_tokens (
    user_name VARCHAR(50),
    token VARCHAR(100),
    created_at DATETIME
);

DELETE FROM intel_reports;
DELETE FROM notifications;
DELETE FROM people_status;
DELETE FROM people;

