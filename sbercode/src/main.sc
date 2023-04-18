require: slotfilling/slotFilling.sc
  module = sys.zb-common
  
require: js/selection.js

patterns:
    $AnyText = $nonEmptyGarbage
    
    
theme: /

    state: Start
        q!: $regex</start>
        a: Начнём. Вот примеры того что я могу:
        buttons:
            "Начать тест"
        
    state: Приветствие
        intent!: /привет
        a: Привет привет
    
    state: Прощание
        intent!: /пока
        a: Пока пока
            
    state: НачатьТест
        q!: (старт|поехали|запускай|начинай|дальше|начать|начни|запусти) [игру|тест]
        a: Запускаю тест.
        script:
            startGame($context);

    state: НачатьЗаново
        q!: (перезапусти|заново|закончить|дальше|перезапустить|переиграй|переиграть) [игру|тест]
        a: Перезапускаю тест.
        script:
            restartGame($context);

    state: ПервыйВариант
        q!: (первый|один) [вариант|номер]
        a: выбираю первый вариант.
        script:
            firstAnswer($context);

    state: ВторойВариант
        q!: (второй|два) [вариант|номер]
        a: выбираю второй вариант.
        script:
            secondAnswer($context);

    state: ТретийВариант
        q!: (третий|три) [вариант|номер]
        a: выбираю третий вариант.
        script:
            thirdAnswer($context);
            
    state: ЧетвертыйВариант
        q!: (четвертый|четыре) [вариант|номер]
        a: выбираю четвертый вариант.
        script:
            fourthAnswer($context);

    state: ПятыйВариант
        q!: (пятый|пять) [вариант|номер]
        a: выбираю пятый вариант.
        script:
            fifthAnswer($context);

    state: ШестойВариант
        q!: (шестой|шесть) [вариант|номер]
        a: выбираю шестой вариант.
        script:
            sixthAnswer($context);

    state: Спасибо
        intent!: /спасибо
        if: $request.rawRequest.payload.character.name === 'Джой' || $request.rawRequest.payload.character.name === 'Афина'
            a: Рада помочь.
        else:
            a: Рад помочь.
            
                
    state: Помощь
        q!: (Помощь)[что можешь|что ты]
        if: $request.rawRequest.payload.character.name === 'Сбер' || $request.rawRequest.payload.character.name === 'Афина'
            a: Чтобы начать тест, вы можете, к примеру, попросить меня запустить его командой "Старт". Если вам нужно перезапустить тест, то попросите меня перезапустить его, например, командой "Перезапусти". 
        else:
            a: Чтобы начать тест, ты можешь, к примеру, попросить меня запустить его командой "Старт". Если тебе нужно перезапустить тест, то попроси меня перезапустить его, например, командой "Перезапусти". 
        buttons:
            "Начать тест"
        buttons:
            "Перезапустить тест"
        
    state: ИнфоПриложения
        q!: (что ты можешь|расскажи|покажи|продемонстрируй|кто ты|информация)[что можешь|что ты]
        if: $request.rawRequest.payload.character.name === 'Сбер' || $request.rawRequest.payload.character.name === 'Афина'
            a: Это приложение интеллектуальный вызов. В нем вы можете запустить, перезапустить тест, чтобы проверить свои интеллектуальные способности. 
        else:
            a: Это приложение интеллектуальный вызов. В нем ты можешь запустить, перезапустить тест, чтобы проверить свои интеллектуальные способности. 
        buttons:
            "Начать тест"
        buttons:
            "Перезапустить тест"
                
    
    state: Fallback
        event!: noMatch
        if: $request.rawRequest.payload.character.name === 'Сбер'
            a: Не очень вас понял. Вы сказали: {{$request.query}}. Воспользуйтесь командой "Помощь".
        if: $request.rawRequest.payload.character.name === 'Афина'
            a: Не очень вас поняла. Вы сказали: {{$request.query}}. Воспользуйтесь командой "Помощь".
        if: $request.rawRequest.payload.character.name === 'Джой'
            a: Не очень тебя поняла. Ты сказал: {{$request.query}}. Воспользуйся командой "Помощь".
        buttons:
            "Помощь"
        buttons:
            "Информация"