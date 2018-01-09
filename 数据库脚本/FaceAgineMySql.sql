CREATE DATABASE `frsdb`;

USE `frsdb`;

create table `frsdb`.`person`
(
	`id` int(11) AUTO_INCREMENT,
	`person_dataset_id` int(11) NULL,
	`name` nvarchar(50) NULL,
	`gender` char(1) NULL,
	`card_id` varchar(50) NULL,
	`bitrhday` datetime NULL,
	`image_id` varchar(60) NULL,
	`face_image_path` varchar(200) NOT NULL,
	`feature_data` LongBlob NOT NULL,
	`type` char NULL,
	`create_time` datetime NOT NULL,
	`modified_time` datetime NOT NULL,
	`quality_score` int(8),
	`remark` nvarchar(50) NULL,
	PRIMARY KEY (`id`),
	UNIQUE KEY `id` (`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;

create table `frsdb`.`hitrecord`
(
	`id` int(11) AUTO_INCREMENT,
	`face_query_image_path` varchar(200) NOT NULL,
	`threshold` float NOT NULL,
	`occur_time` datetime NOT NULL,
	`task_id` int(11),
	`remark` nvarchar(50) NULL,
	PRIMARY KEY (`id`),
	UNIQUE KEY `id` (`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;

create table `frsdb`.`hitrecord_detail`
(
	`id` int(11) AUTO_INCREMENT,
	`hit_record_id` int(11) NOT NULL,
	`user_id` int(11) NOT NULL, 
	`rank` int(11) NOT NULL,
	`score` float NOT NULL,
	`remark` nvarchar(50) NULL,
	PRIMARY KEY (`id`),
	UNIQUE KEY `id` (`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;

create view `frsdb`.`hitalert` as 
select 
hit.id,
hit.face_query_image_path,
hit.threshold,
hit.occur_time,
hit.task_id,
detail.id as detail_id,
detail.rank,
detail.score,
usr.id as user_id,
usr.name as user_name,
usr.gender as user_gender,
usr.card_id as user_card_id,
usr.person_dataset_id as user_person_dataset_id,
usr.image_id as user_image_id,
usr.face_image_path as user_face_image_path,
usr.type as user_type,
usr.create_time as user_create_time,
usr.modified_time as user_modified_time,
usr.quality_score as user_quality_score
FROM 
(`frsdb`.`hitrecord_detail` as detail
left join `frsdb`.`hitrecord` as hit on detail.hit_record_id=hit.id) 
left join `frsdb`.`person` as usr on detail.user_id = usr.id;


create table `frsdb`.`person_dataset`
(
	`id` int(11) AUTO_INCREMENT,	
	`name` nvarchar(50) NOT NULL,
	`type` nvarchar(50) NULL,
	`source` nvarchar(50) NULL,
	`create_time` datetime NULL,
	`remark` nvarchar(50) NULL,
	PRIMARY KEY (`id`),
	UNIQUE KEY `datasetname` (`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;

create table `frsdb`.`device`
(
	`id` int(11) AUTO_INCREMENT,	
	`name` nvarchar(50) NOT NULL,
	`video_address` nvarchar(200) NOT NULL,
	`departmentment_id` nvarchar(50) NULL,
	`longitude` double(5,2) NULL,
	`latitude` double(5,2) NULL,
	`location_type` nvarchar(50) NULL,
	`type` nvarchar(50) NULL,
	`remark` nvarchar(50) NULL,
	PRIMARY KEY (`id`),
	UNIQUE KEY `id` (`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;

create table `frsdb`.`surveillance_task`
(
	`id` int(11) AUTO_INCREMENT,
	`name` nvarchar(50) NOT NULL,
	`person_dataset_id` int(11) NOT NULL,
	`device_id` int(11) NOT NULL,
	`type` nvarchar(50) NULL,	
	`create_time` datetime NOT NULL,
	`start_time` datetime,
	`end_time` datetime NULL,
	`remark` nvarchar(50) NULL,
	PRIMARY KEY (`id`),
	UNIQUE KEY `id` (`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `frsdb`.`person_dataset` (`name`) VALUES ('frsdb');



