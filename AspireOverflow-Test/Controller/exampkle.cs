
///create Article

"artileId": 0,
    "title": "string",
    "content": "string",
    "image": "string",
    "articleStatusID": 0,
    "reviewerId": 0,
    "datetime": "2022-06-19T18:16:48.713Z",
    "isPrivate": true,
    "createdBy": 0,


///Create Comment
    "articleCommentId": 0,
  "comment": "string",
  "datetime": "2022-06-19T18:18:06.949Z",
  "userId": 0,
  "createdBy": 0,
  "articleId": 0,



/// Change Article Status
  ArticleId
 1

ArticleStatusID
22



///Delete Article

ArticleId
1


///Latest Article
Range
3



//Trending

Range
4



///Articles by userId

ArticleId
1



//GetAll

///Aget Articlesby useraID

///Get Private Articles

UserId
2


///GetArticlesbytitle

Title
xyz


//Articleby name

AuthorName
Pooja


//Articlebyarticlestatusid

ArticleStatusID
1

//Get Comments

ArticleId
1






















//Reviewre Dash

ReviewerId
1



//Create User
"userId": 0,
  "fullName": "kavi",
  "genderId": 1,
  "aceNumber": "ACE0080",
  "emailAddress": 'kavi@gmail.com",
  "password": "Kavi01Kavi@10",
  "dateOfBirth": "2000-06-19T18:32:03.137Z",
  "verifyStatusID": 3,
  "isReviewer": false,
  "userRoleId": 1,
  "designationId": 1,
  




//Change UserVerifystatus

Name	Description
UserId
1


IsVerified
true



//Update USer by ISreviewer

UserId
1

IsReviewer
true



//Remove User

UserId
1


//Userby verifystatsusid


VerifyStatusID
1




//UserByRoleId

RoleId
1



//GetUserByISReviewer

IsReviewer
true






















//reate Query
"queryId": 0,
  "title": "string",
  "content": "string",
  "code": "string",
  "isSolved": true,
  "isActive": true,
  "createdBy": 0,


  //removeQuery
  QueryId
1




///markQueryasSolved
QueryId
1


//GetQuery
QueryId
1



//Latest
Range
3


//trending
Range
3


//GetQueryByISSolved

IsSolved
true



///Comment
queryCommentId": 0,
  "comment": "string",
  "datetime": "2022-06-19T18:44:29.665Z",
  "code": "string",
  "queryId": 0,
  "createdBy": 0


  //getCommet
QueryId
1


//AddSpam
spamId": 0,
  "reason": "string",
  "queryId": 0,
  "userId": 0,
  "verifyStatusID": 0

//UpdateSpamStatus

SpamId
1

VerifyStatusID
2









