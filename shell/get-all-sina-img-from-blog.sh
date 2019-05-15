#!/bin/sh

rm -rf blog_url_list

get_img_url()
{
	for url in `cat blog_url_list`;
	do
		if [ `curl -s $url | awk '/sinaimg/ {print $0}' | wc -l` -gt 0 ]
		then
			folder_name=`curl -s $url | awk '/postTitle2/ {print $0}' | cut -d "<" -f 2 | cut -d ">" -f 2 | sed 's/ //g'`
			mkdir $folder_name
			img_list=`curl -s $url | awk '/sinaimg/ {print $2}' | awk -F\" '/src/ {print $2}'`
			for img in `echo $img_list`;
			do
				img_name=`echo $img | cut -d "/" -f 5`
				curl $img -o $folder_name/$img_name
			done
		fi
	done
}

default_page="https://www.cnblogs.com/xiyin/default.html?page="
get_all_blog_url()
{
	for i in `seq 9`;
	do
		curl -s https://www.cnblogs.com/xiyin/default.html?page=$i | awk '/DayList_TitleUrl_0/ {print $4}'| cut -d "\"" -f 2 >> blog_url_list
	done	
}

get_all_blog_url
get_img_url

#while [ $beginNum -le $endNum ];
#do
#	getImgUrl $beginNum `expr $beginNum + $lap` &
#	beginNum=`expr $beginNum + $lap + 1`

#	if [ $beginNum > $endNum ]
#	then
#		getImgUrl `expr $beginNum - $lap - 1` $endNum &
#	fi
#done
