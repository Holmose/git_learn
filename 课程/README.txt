课程安排

班级
	属性
		Id、名字、班主任
	行为
		创建班级、删除班级、修改班级、查看班级情况、管理学生

学生
	属性
		Id、姓名、班级Id
	行为
		增删改查、查看我的课表

老师
	属性
		Id、姓名
	行为
		增删改查、查看我的课表

课程科目
	属性
		Id、名称
	行为
		增删改查

课程安排
	属性
		班级Id、课程科目Id、老师Id


##Enable-Migrations -ContextTypeName CourseManagerEntities
##Add-Migration Create201911271710
Update-Database