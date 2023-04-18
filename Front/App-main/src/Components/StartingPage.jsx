import React, { useState } from "react";
import Card from "./Card";

import "./StartingPage.css";

const StartingPage = ({
  setShowStartingPage,
  setShowQuestionsPage,
  topScore
}) => {
  const startGame = () => {
      setShowStartingPage(false);
      setShowQuestionsPage(true);
  };

  return (
    <Card>
      <h1 className="header">Испытание ума с интеллектуальным вызовом!</h1>
     

      <button className="start_btn" onClick={startGame}>
        Сыграем!
      </button>

      <p className="top_score">
        Лучший счет: <span>{topScore}</span>
      </p>
    </Card>
  );
};

export default StartingPage;
