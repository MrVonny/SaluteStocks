import React, { useEffect } from "react";
import { useState } from "react";
import Question from "./Question";

import { questions } from "../questions";

const QuestionsPage = ({
  setShowPages,
  score,
  setScore,
  setShowQuestionsPage,
  setShowFinalPage,
  handleClick,
  questionIndex,
  setQuestionIndex
}) => {

  return (
    <>
      <Question
        questionIndex={questionIndex}
        questions={questions}
        setQuestionIndex={setQuestionIndex}
        setShowQuestionsPage={setShowQuestionsPage}
        setShowFinalPage={setShowFinalPage}
        score={score}
        setScore={setScore}
        handleClick={handleClick}
      />
    </>
  );
};

export default QuestionsPage;
