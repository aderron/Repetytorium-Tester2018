function retrieveAllQuestions() {
    var questions = [];
    for (var i = 1; i <= 321; i++) {
        try {
            var question = retrieveQuestion(i);
            questions.push(question);
            console.log(JSON.stringify(question));
        }
        catch (e) {
        }
    }

    return questions;
}

function retrieveQuestion(number) {
    var questionId = 'mtq_question_text-'+ number + '-1';
    var answerA = 'mtq_answer_text-'+ number + '-1-1';
    var answerB = 'mtq_answer_text-'+ number + '-2-1';
    var answerC = 'mtq_answer_text-'+ number + '-3-1';
    var answerD = 'mtq_answer_text-'+ number + '-4-1';

    var isCorrectA = 'mtq_marker-'+ number + '-1-1';
    var isCorrectB = 'mtq_marker-'+ number + '-2-1';
    var isCorrectC = 'mtq_marker-'+ number + '-3-1';
    var isCorrectD = 'mtq_marker-'+ number + '-4-1';

    var retVal = {};
    retVal.Question = document.getElementById(questionId).innerHTML;
    retVal.A = document.getElementById(answerA).innerHTML;
    retVal.B = document.getElementById(answerB).innerHTML;
    retVal.C = document.getElementById(answerC).innerHTML;
    retVal.D = document.getElementById(answerD).innerHTML;

    retVal.IsA = document.getElementById(isCorrectA).classList.contains('mtq_correct_marker');
    retVal.IsB = document.getElementById(isCorrectB).classList.contains('mtq_correct_marker');
    retVal.IsC = document.getElementById(isCorrectC).classList.contains('mtq_correct_marker');
    retVal.IsD = document.getElementById(isCorrectD).classList.contains('mtq_correct_marker');

    return retVal;
}
