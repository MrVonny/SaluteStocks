import { useEffect, useState, useRef, useReducer } from "react";
import "./App.css";
import FinalPage from "./Components/FinalPage";
import QuestionsPage from "./Components/QuestionsPage";
import StartingPage from "./Components/StartingPage";
import {questions} from "./questions.js";

import {
  createSmartappDebugger,
  createAssistant,
} from "@salutejs/client";

const initAssistant = (getState/*: any*/) => {
  if (process.env.NODE_ENV === "development") {
    return createSmartappDebugger({
      token: "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJqdGkiOiJmOWZlZDhmNy0xYzE1LTRkZDktYjg1ZS01YWI5ZDg4NDM0NGMiLCJzdWIiOiJmZjAwMTgwYWFlMjhmMjRkYzgyMGQ2MTg4MmM5ZjUxNmE5ZmQwMzRiNThiNjIwMmExMzJmNzk0Y2FiMjQ0YTA0ODFiZDAiLCJpc3MiOiJLRVlNQVNURVIiLCJleHAiOjE2ODE2NzYwMzksImF1ZCI6IlZQUyIsImlhdCI6MTY4MTU4OTYyOSwidHlwZSI6IkJlYXJlciIsInNpZCI6IjE4ZDc5ZWJjLTQ0NjgtNGQwYy1iNmIwLTY1MjM5YjljOWUwOSJ9.WlsWlYxkVM_t7HnVRlngAI-8-GsKBFWr1P_A1ySBQos6hPTs73oVW2_KJFfIv2Mu1UyxEPXFRHYlZLDD8CILhFIlRbQLjcyDSSeaRwOq_JjPKLxbD-Lo6dBZ8WLx0WruBWgbDzPqvKmj55SOccE411T1pr255Ywxf2DcjALDtXq6SkLsKWbOMgIT5tVl63uoMCF6X8E39-iKbb45qERv7VCd_sXb9tbJfthIsq_vQ8MKOEt1ssyopwcdPpQ9fKpUkneYWwh6uCFKZpyLiMzt3Z2RsnboC7jH4VOQTQlfkbd7Kjw-nVj8dYMy5YVB3IBAM87xW9US35u0Mh2a0Ckn9L1M2RvnIFPFtX-qwAtVC-5255I0QvJUBi0u-iOertPQRbCIyQdcs9l642bmm-9DZgJCQ_4DngVOJl55i5dygKE83_RD61EisxQz8ee3XiCtOvVKwfOpbxpmp9QcvtlV3w8sz5cLTDbJAp50tp0PTJMBKlqftxXqQhySgFOxyJB5hsGbHFz-kx1gDwCDpq28JS9Ev1hXJfxt9kg3N-3uc2litn0lZ77KFt6ffw9nrZrvNRDDHGS31ciZWq6FetHzsSNZAsphLZg-_5JErrOth7ac9hKq0rq6b_b5-ZMpudoPVT6h7vJOQL1XW22yfidLmRIQ4DKRxZw7L1VCfKWQUbI",
      initPhrase: `Открой ${process.env.REACT_APP_SMARTAPP}`,
      getState,
    });
  }
  return createAssistant({ getState });
};


function App() {
  const [username, setUsername] = useState("");

  const [score, setScore] = useState(0);
  const [topScore, setTopScore] = useState(0);

  const [showStartingPage, setShowStartingPage] = useState(true);
  const [showQuestionsPage, setShowQuestionsPage] = useState(false);
  const [showFinalPage, setShowFinalPage] = useState(false);
  const [appState, dispatch] = useReducer();
  const [questionIndex, setQuestionIndex] = useState(0);
  const assistant = useRef();

  var state = {
    minutes: [],
    };

    const handleClick = (isCorrect) => { // определяем функцию handleClick
      if (questionIndex < 19) {
        if (isCorrect) {
          setScore((score) => (score += 9));
        }
  
        setQuestionIndex(questionIndex + 1);
      } else {
        if (isCorrect) {
          setScore((score) => (score += 15));
        }
  
        setShowQuestionsPage(false);
        setShowFinalPage(true);
        setQuestionIndex(0);
      }
    };

    const getStateForAssistant = () => {
      console.log("getStateForAssistant: this.state:", state);
      const state_ = {
      item_selector: {
      items: state.minutes.map(({ id, title }, index) => ({
      number: index + 1,
      id,
      title,
      })),
      },
      };
      console.log("getStateForAssistant: state:", state);
      return state_;
    };
  
    useEffect(() => {
      assistant.current = initAssistant(() => getStateForAssistant());
      assistant.current.on("start", (event) => {
      console.log(`assistant.on(start)`, event);
      });
      assistant.current.on("data", (event /*: any*/) => {
        if (event.type == "smart_app_data") {
          console.log(event);
          if (event.sub != undefined) {
            console.log("Sub", event.sub);
            
          } else if (event.user_id != undefined) {
            console.log("UserId", event.user_id);
          }
        }
        console.log(`assistant.on(data)`, event);
        const { action } = event;

        dispatchAssistantAction(action);
        
  });
    },
    [appState]);

    const dispatchAssistantAction = async (action) => {
      console.log("dispatchAssistantAction", action);
      if (action) {
        console.log(action.minutes);
        const answerDivs = document.querySelectorAll('div.answer');
        switch (action.type) {
          case "startGame":
            console.log("startGame")
            console.log(questions[questionIndex].answers[0].correctAnswer)
            setShowQuestionsPage(true);
            setShowStartingPage(false);
            break;
          case "restartGame":
            console.log("restartGame")
            setShowQuestionsPage(false);
            setShowFinalPage(false)
            setShowStartingPage(true);
            setQuestionIndex(0);
            setScore(0);
            break;
          case "firstAnswer":
            console.log("firstAnswer")
            answerDivs[0].click();
            break;
          case "secondAnswer":
            console.log("secondAnswer")
            answerDivs[1].click();
            break;
          case "thirdAnswer":
            console.log("thirdAnswer")
            answerDivs[2].click();
            break;
          case "fourthAnswer":
            console.log("fourthAnswer")
            answerDivs[3].click();
            break;
          case "fifthAnswer":
            console.log("fifthAnswer")
            answerDivs[4].click();
            break;
          case "sixthAnswer":
            console.log("sixthAnswer")
            answerDivs[5].click();
            break;
          default:
            break;
          }
        }
    };

  return (
    <>
      {showStartingPage && (
        <StartingPage
          setShowStartingPage={setShowStartingPage}
          setShowQuestionsPage={setShowQuestionsPage}
          topScore={topScore}
        />
      )}
      {showQuestionsPage && (
        <QuestionsPage
          questionIndex={questionIndex}
          setQuestionIndex={setQuestionIndex}
          score={score}
          setScore={setScore}
          setShowQuestionsPage={setShowQuestionsPage}
          setShowFinalPage={setShowFinalPage}
          handleClick={handleClick}
        />
      )}
      {showFinalPage && (
        <FinalPage
          score={score}
          topScore={topScore}
          setTopScore={setTopScore}
          setShowStartingPage={setShowStartingPage}
          setShowFinalPage={setShowFinalPage}
          setScore={setScore}
        />
      )}
    </>
  );
}

export default App;
