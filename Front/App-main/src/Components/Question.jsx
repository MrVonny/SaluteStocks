import React from "react";
import Card from "./Card";

import "./Question.css";

const Question = ({
  questionIndex,
  setQuestionIndex,
  questions,
  setShowQuestionsPage,
  setShowFinalPage,
  score,
  setScore,
  handleClick
}) => {

  return (
    <Card>
      <div class="container">
        <img src={questions[questionIndex].questionImg} class="question-image"></img>
      </div>
      <div className="answers">
        {questions[questionIndex].answers.map((answer, i) => (
          <div
            key={i}
            className="answer"
            onClick={() => handleClick(answer.correctAnswer)}
          >
            <p>{answer.answerText}</p>
          </div>
        ))}
      </div>

      <p className="score">
        Счет: <span>{score}</span>
      </p>

      <p className="question_number">
        Вопрос <span>{questionIndex + 1}</span>/20
      </p>
    </Card>
  );
};

export default Question;
