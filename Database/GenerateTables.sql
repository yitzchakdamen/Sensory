
CREATE TABLE IF NOT EXISTS users 
(
    id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(30),
    user_name VARCHAR(30) UNIQUE,
    game_stage INT DEFAULT 1,
    score INT DEFAULT 0,
    last_name VARCHAR(30)
);

CREATE TABLE tokens (
    user_name VARCHAR(30) UNIQUE,
    token VARCHAR(100) UNIQUE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (token),
    FOREIGN KEY (user_name) REFERENCES users(user_name) ON DELETE CASCADE
);



DELETE FROM intel_reports;
DELETE FROM notifications;
DELETE FROM people_status;
DELETE FROM people;

