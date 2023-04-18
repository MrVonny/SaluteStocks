import React from "react";
import Card from "./Card";

import "./FinalPage.css";

const FinalPage = ({
  score,
  setShowFinalPage,
  setShowStartingPage,
  topScore,
  setTopScore,
  setScore,
  username,
  setUsername,
}) => {
  const handleClick = () => {
    if (score > topScore) {
      setTopScore(score);
    }

    setShowFinalPage(false);
    setShowStartingPage(true);
    setScore(0);
    setUsername("");
  };

  return (
    <Card>
      <h1 className="heading">Тест завершен, умник!</h1>

      <h3 className="primary_text">Примерный iq:</h3>

      <h3 className="final_score">{score}</h3>

      <button className="play_again_btn" onClick={handleClick}>
        Пройти снова
      </button>
    </Card>
  );
};

export default FinalPage;
